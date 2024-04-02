using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput input = null;
    private Rigidbody rb;
    //private CharacterController character;
    private Vector2 moveVector = Vector2.zero;
    public float playerSpeed = 200f;
    private Vector3 targetVelocity = Vector3.zero;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 changeInVelocity = Vector3.zero;


    private void Awake()
    {
        input = new PlayerInput();
    }

    void Start()
    {
        //CursorLockMode cursorLockMode = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = 100.0f;
        }*/
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = 300.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovementCalculation();
    }

    private void OnEnable()
    {
        input.Enable();
        //character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        input.Player.Movement.performed += PlayerMovementPerformed;
        input.Player.Movement.canceled += PlayerMovementCancelled;
        input.Player.Jump.performed += PlayerJumpPerformed;
        input.Player.Down.performed += PlayerDownPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        rb = null;
        //character = null;
        input.Player.Movement.performed -= PlayerMovementPerformed;
        input.Player.Movement.canceled -= PlayerMovementCancelled;
        input.Player.Jump.performed -= PlayerJumpPerformed;
        input.Player.Down.performed -= PlayerDownPerformed;
    }

    private void PlayerMovementPerformed(InputAction.CallbackContext value)
    {
        //UnityEngine.Debug.Log("HEllo");
        moveVector = value.ReadValue<Vector2>();
        //rb.AddForce(transform.forward * playerSpeed * Time.deltaTime);
    }

    private void PlayerMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
   
    private void PlayerJumpPerformed(InputAction.CallbackContext value)
    {
        rb.AddForce(0, 2500, 0);
    }
    
    private void PlayerDownPerformed(InputAction.CallbackContext value)
    {
        rb.AddForce(0, -2500, 0);
    }

    private void PlayerMovementCalculation()
    {
        targetVelocity = new Vector3(moveVector.x, 0, moveVector.y) * playerSpeed;
        targetVelocity = transform.TransformDirection(targetVelocity);
        rb.AddForce(targetVelocity);
    }
}
