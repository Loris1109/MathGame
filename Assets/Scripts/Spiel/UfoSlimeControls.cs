
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class UfoSlimeControls : BaseControls
{

    #region public variables 
    public new Rigidbody2D rigidbody2D;
    public float fuel = 100;
    public float refuelSpeed = 1f;
    public float fuelCapasity = 10f;
    public float fuelUse = 1.5f;
    public FuelBar fuelBar;
    public float maxHight = 0.5f;
    public float jetpackForce = 3f;
    public bool isFlying = false;
    public float movementSmoothing = .05f;
    #endregion

    #region private variables
    float ground;
    private Vector3 velocity = Vector3.zero;
    float verticalMove;
    float vMove;
    float sensetivity = 0.5f;
    [SerializeField] float sensetivityControl = -0.5f;
    #endregion

    #region methods

    public void Start()
    {
        ground = transform.position.y;
        fuelBar.SetMaxFuel(fuelCapasity);

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isFlying == true)
        {
            vMove = joystick.Vertical * jetpackForce;
            Vector3 targetVelocity = new Vector2(rigidbody2D.velocity.x, vMove * 10f);

            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
        }
    }
    public override void MovmentControls()
    {
        base.MovmentControls();

        verticalMove = joystick.Vertical;

        if (isFlying == true)
        {
            sensetivity = 0f;
        }
        else
        {
            sensetivity = sensetivityControl;
        }

        if (verticalMove >= sensetivity && fuel > 0f)
        {
              
            fuel -= fuelUse * Time.deltaTime;
            fuelBar.SetFuel(fuel);
            if(fuel < 0f && isFlying == true)
            {
                isFlying = false;
            }
            else
            {
                isFlying = true;
            }
           
        }

        if ( verticalMove <= sensetivity && fuel < fuelCapasity)
        {
            
            fuel += refuelSpeed * Time.deltaTime;
            fuelBar.SetFuel(fuel);

            if (isFlying == true)
            {
                isFlying = false;
            }
        }

        
    }



    #endregion
}
