using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackBox attackBox;

    public float damage;
    public float clickTime;
    public float endPhaseTime;


    PlayerAnimationHandler playerAnimationHandler;
    PlayerMover playerMover;
    Rigidbody rb;

    bool canAttack = true;

    int attackQue;


    private void Awake()
    {
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
        playerMover = GetComponent<PlayerMover>();
        rb = GetComponent<Rigidbody>();
    }


    public void InitiateAttack()
    {
        //can attack
        if (canAttack)
        {
            //start attack
            StartCoroutine(LightAttackCombo());
            canAttack = false;
        }

        attackQue++;
    }

    IEnumerator LightAttackCombo()
    {
        //lock rotation and movement input
        playerMover.lockMovement = true;
        playerMover.lockRotation = true;

        // Attack 1
        #region Attack 1
        //animation
        playerAnimationHandler.LightAttack(true, 1);
        #endregion

        yield return new WaitForSeconds(clickTime);

        // Attack 2
        #region Attack 2
        if (attackQue >= 2)
        {
            playerAnimationHandler.LightAttack(true, 1);
            yield return new WaitForSeconds(clickTime);
        }
        #endregion

        

        // Attack 3
        #region Attack 3
        if (attackQue >= 3)
        {
            playerAnimationHandler.LightAttack(true, 1);
            
        }
        #endregion

        // End phase timer
        yield return new WaitForSeconds(endPhaseTime);

        // reset animation
        playerAnimationHandler.LightAttack(false, 1);

        //unlock rotation and movement input
        playerMover.lockMovement = false;
        playerMover.lockRotation = false;

        //reset attack input count
        attackQue = 0;

        //can attack again
        canAttack = true;
    }

    public void ReadyForNextCombo ()
    {

    }

    public void DoDamage()
    {
        //deal damage
        foreach (IDamageable damagebleEntities in attackBox.damagebleEntities)
        {
            damagebleEntities.TakeDamage(damage);
        }
    }

}