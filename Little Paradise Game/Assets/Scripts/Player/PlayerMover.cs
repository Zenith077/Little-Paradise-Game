using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputHandler _input;

    Rigidbody rb;
    GameObject mainCamera;

    PlayerAnimationHandler animHandler;

    // Movement Var
    public float moveSpeed;

    // Rotation Var
    public float turnSpeed = 1;
    float turnSmoothVelocity;
    float cameraAngle = 45;

    public bool lockMovement = false;
    public bool lockRotation = false;

    private void Awake()
    {
        // find components
        _input = GetComponent<InputHandler>();
        animHandler = GetComponent<PlayerAnimationHandler>();
        rb = GetComponent<Rigidbody>();

        // find camera + camera angle
        mainCamera = GameObject.FindWithTag("MainCamera");
        cameraAngle = mainCamera.transform.eulerAngles.y;

        // Log Errors
        #region LogError
        if (_input == null)
            Debug.LogError(_input + "not found!");

        if (mainCamera == null)
            Debug.LogError(mainCamera + "not found!");

        if (animHandler == null)
            Debug.LogError(animHandler + "not found!");

        if (rb == null)
            Debug.LogError(rb + "not found!");
        #endregion
    }

    private void Update()
    {
        //calculate rotation
        if (!lockRotation)
        {
            Rotation();
        }

        // animation for run / idle.    change this
        if(_input.InputDirRaw.x != 0 || _input.InputDirRaw.z != 0)
        {
            animHandler.MovementAnimation(true);
        } else
        {
            animHandler.MovementAnimation(false);
        }
    }

    private void FixedUpdate()
    {
        // calculate movement
        if (!lockMovement)
        {
            Movement(_input.InputDirRaw);
        }
    }

    void Rotation()
    {
        if (_input.InputDirRaw.magnitude >= 0.1f)
        {
            //calculate angle from input
            float targetAngle = Mathf.Atan2(_input.InputDirRaw.x, _input.InputDirRaw.z) * Mathf.Rad2Deg + cameraAngle;
            // Smoothing
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed);
            // Apply rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    public void HardSetRotation()
    {
        //calculate angle from input
        float targetAngle = Mathf.Atan2(_input.InputDirRaw.x, _input.InputDirRaw.z) * Mathf.Rad2Deg + cameraAngle;
        // Apply rotation
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    public void RotateTowardsMouse()
    {

    }

    void Movement(Vector3 targetVector)
    {
        //speed
        var speed = moveSpeed * Time.deltaTime;

        // target direction
        targetVector = Quaternion.Euler(0, cameraAngle, 0) * targetVector;

        // deploy movement
        rb.velocity = targetVector.normalized * speed;
        
    }
}
