using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private const float GRAVITY_VALUE = -19.81f;   


    [SerializeField] private float m_Speed = 10.0f;  
    [SerializeField] private float m_JumpHeight = 1.0f; 

    private CharacterController m_Character;    
    [SerializeField] private  float m_JumpVelocity;   

    private Vector2 m_MoveVector;   

    [SerializeField] private int targetLane = 1; // 0: left, 1: middle, 2: right
    private float targetPosition = 0;

    private Vector3 moveDir = Vector3.zero;
    private bool isMoving = false;

    private void Start() {
        SetTargetPosition();
    }

    #region Initialization  
    private void OnEnable()
    {
        m_Character = gameObject.GetComponent<CharacterController>();   
        m_Character.radius = 0.4f;  
    }

    private void OnDisable()
    {
        Destroy(m_Character);   
    }
    #endregion

    private void FixedUpdate()  
    {
        ApplyGravity(); 
    }

    private void Update()
    {
        PlacePlayer();
    }

    

    private void ApplyGravity() 
    {
        // Reset gravity value and return early if grounded
        if (m_Character.isGrounded && m_JumpVelocity < 0)   
        {
            m_JumpVelocity = 0f;    
            return; 
        }

        // Otherwise increment velocity with gravity
        m_JumpVelocity += GRAVITY_VALUE * Time.deltaTime;   

        // Apply velocity
        m_Character.Move(m_JumpVelocity * Time.deltaTime * Vector3.up); 
    }

    private void SetTargetPosition() {
        switch (targetLane) {
            case 0:
                targetPosition = -2;
                break;
            case 1:
                targetPosition = 0;
                break;
            case 2:
                targetPosition = 2;
                break;
        }
    }

    private void PlacePlayer() {
        if (!isMoving) {
            return;
        }

        // Apply movement
        m_Character.Move(moveDir.normalized * m_Speed * Time.deltaTime);

        // If player has reached the target position, stop moving and place it exactly at the target position
        if (moveDir.x > 0) {
            if ( transform.position.x > targetPosition ){
            transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
            isMoving = false;
        }
        } else {
             if ( transform.position.x < targetPosition ){
            transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
            isMoving = false;
        }
        }    

        

    }

    public void MoveLeft() 
    {
        if (isMoving) {
            return;
        }

        targetLane--;
        // Block player from moving out of bounds
        if (targetLane == -1) {
            targetLane = 0;
        }

        moveDir = Vector3.left;
        SetTargetPosition();
        isMoving = true;
    }

    public void MoveRight() 
    {
        if (isMoving) {
            return;
        }

        targetLane++;
        // Block player from moving out of bounds
        if (targetLane > 2) {
            targetLane = 2;
        }

        moveDir = Vector3.right;
        SetTargetPosition();
        isMoving = true;
    }

    public void Jump()  
    {
        // Can't jump in the air
        if (!m_Character.isGrounded)    
        {
            return; 
        }

        // Apply jump to the current velocity
        m_JumpVelocity += Mathf.Sqrt(m_JumpHeight * -GRAVITY_VALUE);    
    }
}                                                                                                                           
