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

    private void Awake()
    {
        robotBody = GetComponent<Rigidbody>();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        RobotMove(inputMaster.PlayerActions.Movement.ReadValue<float>());
        CheckIfRobotGrounded();
        RobotJumpPhysics();
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
        robotBody.velocity = (new Vector2(_direction * speed, robotBody.velocity.y));
    }

    void RobotJump()
    {
        if(onGround)
        {
            Debug.Log("Robot jump");
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
    }

    void RobotDeath()
    {
        robotIsDead = true;
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
