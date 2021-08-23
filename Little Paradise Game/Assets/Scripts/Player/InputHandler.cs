using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Dir inputs
    public Vector3 InputDirRaw { get; private set; }
    public Vector3 InputDir { get; private set; }

    //Dash
    public KeyCode dashKey = KeyCode.Space;
     PlayerDash playerDash;

    // Attack
    public KeyCode attackKey = KeyCode.Mouse0;
     PlayerAttack playerAttack;

    //aimationhandler duuh
     PlayerAnimationHandler playerAnimationHandler;

    //AFK
    public float afkTimer = 10;
    private float currentAFKTime = 10;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
        playerDash = GetComponent<PlayerDash>();

        // Log Errors
        #region LogError
        if (playerAttack == null)
            Debug.LogError(playerAttack + "not found!");

        if (playerAnimationHandler == null)
            Debug.LogError(playerAnimationHandler + "not found!");

        if (playerDash == null)
            Debug.LogError(playerDash + "not found!");
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // AFK timer
        currentAFKTime = currentAFKTime - Time.deltaTime;
        if (Input.anyKey)
        {
            currentAFKTime = afkTimer;
            AFK(false);
        }
        if(currentAFKTime <= 0)
        {
            AFK(true);
        }

        // Directional inputs Raw
        float hraw = Input.GetAxisRaw("Horizontal");
        float vraw = Input.GetAxisRaw("Vertical");
        InputDirRaw = new Vector3(hraw, 0f, vraw);

        // Directional inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        InputDir = new Vector3(h, 0f, v);

        // keyboard inputs
        KeyInputs();

    }

    void KeyInputs()
    {
        //dash
        if (Input.GetKeyDown(dashKey))
        {
            playerDash.InitiateDash(InputDirRaw);
        }

        //attack
        if (Input.GetKeyDown(attackKey))
        {
            playerAttack.InitiateAttack();
        }
    }

    //afk
    public void AFK(bool afk)
    {
        playerAnimationHandler.AFKAnimations(afk);
    }
    
}
