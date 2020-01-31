using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpForce;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private CharacterController controller;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    private float fallVelocity;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Animator animator;
    private float blendSpeed;
    private PlayerInput controls;
    private float jumpPressed;

    void Awake()
    {
        horizontalMove = 0f;
        verticalMove = 0f;

        controls = new PlayerInput();
        controls.Player.Movement.performed += ctx => horizontalMove = ctx.ReadValue<Vector2>().x;
        controls.Player.Movement.canceled += ctx => horizontalMove = 0f;
        controls.Player.Movement.performed += ctx => verticalMove = ctx.ReadValue<Vector2>().y;
        controls.Player.Movement.canceled += ctx => verticalMove = 0f;

        controls.Player.Jump.performed += ctx => jumpPressed = ctx.ReadValue<float>();  
        controls.Player.Jump.canceled += ctx => jumpPressed = 0f;  

        Cursor.visible = false;
    }
    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Smooth movement, comment to use the New Input System.
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // Animation blending
        blendSpeed = new Vector2(horizontalMove, verticalMove).sqrMagnitude;
        animator.SetFloat("Blend", blendSpeed);

        // Clamped Input
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        // Camera direction
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        // movePlayer => direction we are headed
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        // We apply the speed
        movePlayer *= playerSpeed;
        // We look at the camera direction
        controller.transform.LookAt(controller.transform.position + movePlayer);

        // We apply the gravity
        if(controller.isGrounded)
        {
            animator.SetBool("isJumping", false);
            fallVelocity = -gravity * Time.deltaTime;
        } else {
            fallVelocity -= gravity * Time.deltaTime;
        }
        movePlayer.y = fallVelocity;

        // Jump
        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }

        controller.Move(movePlayer * Time.deltaTime);
    }

}
