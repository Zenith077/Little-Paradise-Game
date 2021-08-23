using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    public float dashEndTime;

    public float dashCooldown;

    bool canDash = true;

    public LayerMask ignoreLayer;
    PlayerMover playerMover;

    Rigidbody rb;

    PlayerAnimationHandler playerAnimationHandler;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMover = GetComponent<PlayerMover>();
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
    }

    public void InitiateDash(Vector3 targetVector)
    {
        if (canDash)
        {
            StartCoroutine(Dash(targetVector, dashSpeed, dashTime));
            playerMover.lockMovement = true;
            playerMover.lockRotation = true;

            canDash = false;
        }

    }

    public void CustomDash(Vector3 targetVector, float speed, float time)
    {
        StartCoroutine(Dash(targetVector, speed, time));
    }

    IEnumerator Dash (Vector3 targetVector, float speed, float time)
    {
        //timer
        float startTime = Time.time;

        //set rotation 
        playerMover.HardSetRotation();

        //animation
        playerAnimationHandler.DashAnimation(true);
        //apply dash
        while (Time.time < startTime + time)
        {
            //get direction and target position
            Vector3 targetDir = Quaternion.Euler(0, 135, 0) * -targetVector;

            //the dashing part
            rb.velocity = targetDir.normalized * speed;

            yield return null;

        }

        //reset velocity
        rb.velocity = Vector3.zero;

        //end timer
        yield return new WaitForSeconds(dashEndTime);

        //end dash
        playerMover.lockMovement = false;
        playerMover.lockRotation = false;
        

        //start cooldown
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
        yield return null;
    }
}
