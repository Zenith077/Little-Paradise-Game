using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        #region LOG ERROR
        if (animator == null)
            Debug.Log(animator + "not found!");
        #endregion
    }

    public void MovementAnimation(bool value)
    {
        animator.SetBool("Run", value);
    }

    public void AFKAnimations(bool state)
    {
        animator.SetBool("AFK", state);
    }

    public void DashAnimation(bool state)
    {
        animator.SetTrigger("Dash");
    }

    public void LightAttack(bool value1, float value2)
    {
        animator.SetBool("LightAttack", value1);
        animator.SetFloat("LightCombo", value2);
    }
}
