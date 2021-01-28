using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RobotScript : MonoBehaviour
{
    private InputMaster inputMaster;
    private Rigidbody robotBody;
    public float speed = 10f;

    private float maxRobotLife;
    [SerializeField]
    private float robotLife = 100f;
    [SerializeField]
    private float jumpDamage = 10f;

    [Header("Jump Variables")]
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private bool buttonJumpHold;
    private bool onGround;
    public LayerMask groundLayer;
    public Vector3 contactOffset;
    public float contactRadius = 0.5f;

    private bool robotIsDead;
    private bool canMove;

    private Animator robotAnim;

    [Space]
    [SerializeField]
    private GameObject cameraFollower;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private bool onSlope;

    private void Awake()
    {
        robotBody = GetComponent<Rigidbody>();
        robotAnim = GetComponent<Animator>();
        SetUpInputs();
        maxRobotLife = robotLife;
    }

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        SlopeDetector();
        if(!robotIsDead && canMove && !gameController.gameOver)
        {
            RobotMove(inputMaster.PlayerActions.Movement.ReadValue<float>());
            CheckIfRobotGrounded();
            RobotJumpPhysics();
            
            if(onSlope && !onGround)
            {
                Vector3 vel = robotBody.velocity;
                vel.x = 0f;
                robotBody.velocity = vel;
            }
        }
    }

    private void LateUpdate()
    {
        CameraFollower();
    }

    void CameraFollower()
    {
        if (transform.position.x >= -1f && transform.position.x < 299f && transform.position.y > -1f)  
        {
            Vector3 robotPos = this.transform.position;
            robotPos.y = transform.position.y + 1.5f;
            cameraFollower.transform.position = robotPos;
        }
    }

    void SetUpInputs()
    {
        inputMaster = new InputMaster();
        inputMaster.PlayerActions.Jump.performed += _ => RobotJump();
        inputMaster.PlayerActions.Jump.canceled += _ => RobotNotJumping();
    }

    void RobotMove(float _direction)
    {
        Debug.Log("Robot is moving");
        robotAnim.SetInteger("XVelocity", (int)_direction);
        robotBody.velocity = (new Vector2(_direction * speed, robotBody.velocity.y));
        FlipRobot((int)_direction);
    }

    void RobotJump()
    {
        if(onGround && !robotIsDead && canMove)
        {
            Debug.Log("Robot jump");
            robotAnim.SetTrigger("Jump");
            buttonJumpHold = true;
            robotBody.velocity = new Vector2(robotBody.velocity.x, 0);
            robotBody.velocity += Vector3.up * jumpForce;
            robotLife -= jumpDamage;
        }
    }

    void RobotNotJumping()
    {
        Debug.Log("Robot not jumping");
        buttonJumpHold = false;
    }

    void CheckIfRobotGrounded()
    {
        onGround = Physics.CheckSphere(transform.position + contactOffset, contactRadius, groundLayer);
        robotAnim.SetBool("OnGround", onGround);
    }

    void RobotJumpPhysics()
    {
        if(!onGround)
        {
            if (robotBody.velocity.y < 0)
            {
                robotBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (robotBody.velocity.y > 0 && !buttonJumpHold)
            {
                robotBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        robotAnim.SetInteger("YVelocity", (int)robotBody.velocity.y);
    }

    void SlopeDetector()
    {
        Vector3 slopeDetectorPos = transform.position;
        slopeDetectorPos.y = transform.position.y + 0.25f;
        if (Physics.Raycast(slopeDetectorPos, transform.TransformDirection(Vector3.forward), 0.75f, groundLayer))
        {
            Debug.Log("Slope");
            onSlope = true;
        } else
        {
            onSlope = false;
        }
    }

    void RobotDeath()
    {
        robotBody.velocity = Vector3.zero;
        robotIsDead = true;
        canMove = false;
        robotAnim.SetTrigger("Death");
    }

    void FlipRobot(int _direction)
    {
        if(_direction != 0)
        {
            Vector3 newRot = transform.eulerAngles;
            newRot.y = 90 * _direction;
            transform.eulerAngles = newRot;
        }
    }

    void CheckColorChange()
    {
        if(robotLife <= maxRobotLife * 0.5f && robotLife > maxRobotLife * 0.25f)
        {
            gameController.ChangeGameHUE(-140f);
        }
        else if(robotLife <= maxRobotLife * 0.25f)
        {
            gameController.ChangeGameHUE(170f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            CheckColorChange();
            if (onGround && robotLife <= 0f && !robotIsDead)
            {
                //Robot death
                Debug.Log("Robot is dead");
                RobotDeath();
            }
        }
        if(collision.gameObject.CompareTag("Rock"))
        {
            if(!robotIsDead)
            {
                RobotDeath();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            //Game Over
            gameController.GameOver();
        }
        if (other.gameObject.CompareTag("Victory"))
        {
            //Win
            gameController.Victory();
        }
    }

    private void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + contactOffset, contactRadius);
        Gizmos.color = Color.blue;
        Vector3 slopeDetectorPos = transform.position;
        slopeDetectorPos.y = transform.position.y + 0.25f;
        Vector3 detectorEnd = slopeDetectorPos;
        detectorEnd.x = slopeDetectorPos.x + 0.75f;
        Gizmos.DrawLine(slopeDetectorPos, detectorEnd);
    }
}
