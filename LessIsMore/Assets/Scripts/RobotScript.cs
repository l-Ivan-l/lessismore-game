using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotScript : MonoBehaviour
{
    private InputMaster inputMaster;
    private Rigidbody robotBody;
    public float speed = 10f;

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

    private void Awake()
    {
        robotBody = GetComponent<Rigidbody>();
        robotAnim = GetComponent<Animator>();
        SetUpInputs();
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
        if(!robotIsDead && canMove)
        {
            RobotMove(inputMaster.PlayerActions.Movement.ReadValue<float>());
            CheckIfRobotGrounded();
            RobotJumpPhysics();
        }
    }

    private void LateUpdate()
    {
        CameraFollowerOnXOnly();
    }

    void CameraFollowerOnXOnly()
    {
        Vector3 robotPos = this.transform.position;
        robotPos.y = transform.position.y + 1.5f;
        cameraFollower.transform.position = robotPos;
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
        if (robotBody.velocity.y < 0)
        {
            robotBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (robotBody.velocity.y > 0 && !buttonJumpHold)
        {
            robotBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        robotAnim.SetInteger("YVelocity", (int)robotBody.velocity.y);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if (onGround && robotLife <= 0f && !robotIsDead)
            {
                //Robot death
                Debug.Log("Robot is dead");
                RobotDeath();
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + contactOffset, contactRadius);
    }
}
