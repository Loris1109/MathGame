using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class SlimeControls : BaseControls
{
    #region private variables
    #endregion



    #region public variables

    #endregion


    #region methods
    
    public override void MovmentControls()
    {
        base.MovmentControls();

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {

            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (verticalMove <= -.5f)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    

    #endregion 
}
