
using UnityEngine;

public class BaseControls : MonoBehaviour
{
    #region private variables

    #endregion

    #region public variables
    public CharacterController2D controller2D;
    public Animator animator;
    public Joystick joystick;
    public Interactable focus;

    RaycastHit2D hitinfo;
    [HideInInspector] public float horizontalMove = 0f;
    public float runSpeed = 15f;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool crouch;
    public float raydistance = 100f;
    #endregion

    #region methods
    void Update()
    {
        MovmentControls();
    }
    public virtual void MovmentControls()
    {
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    } // moving the Player based on the joystick input.
    public virtual void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }


    public virtual void InteractingControls()
    {
        #region shooting and visualising Ray
        Physics2D.queriesStartInColliders = false;

        if (controller2D.m_FacingRight == true)
        {
            hitinfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), raydistance);

        }
        else
        {
            hitinfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), raydistance);
        }


        if (hitinfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.red);

        }
        else if (hitinfo.collider == null && controller2D.m_FacingRight == true)
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * 100, Color.green);
            return;
        }
        else if (hitinfo.collider == null && controller2D.m_FacingRight == false)
        {
            Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector2.left) * 100, Color.green);
            return;
        }
        #endregion

        Interactable interactable = hitinfo.collider.GetComponent<Interactable>();
        if (interactable != null)
        {
            SetFocus(interactable);
        }
    }

    void SetFocus(Interactable newfocus)
    {
        if (newfocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();
            focus = newfocus;
        }

        newfocus.OnFocused(transform);
    }

    #endregion 
}
