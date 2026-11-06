using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMove : MonoBehaviour, InputSystem_Actions.IControllerActions
{
	// Editor references
	[SerializeField] private float rayLength = 0.6f;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private float speed;

	// GameObject components
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator anim;


	// Private variables
	private bool isGravityFlipped;
	private Vector2 moveInput;
	private bool isGrounded = true;
	private bool isMoving = false;

	// Other
	private InputSystem_Actions inputActions;

	private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Controller.SetCallbacks(this);
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

	private void OnDisable()
	{
		inputActions.Disable();
	}

	void Update()
	{
		isGrounded = IsGrounded();
		isMoving = IsMoving();

		anim.SetBool("isMoving", isMoving);

		rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

		if (moveInput.x == -1)
		{
			sr.flipX = true;
		}
		else if (moveInput.x == 1)
		{
			sr.flipX = false;
		}

		if (isGravityFlipped)
		{
			sr.flipY = true;
		}
		else
		{ 
			sr.flipY= false;
		}
	}

	public void OnJump(InputAction.CallbackContext context)
    {
		if (context.performed)
		{
            if (isGrounded)
            {
				Debug.Log("Cambio");
				FlipGravity();
            }
		}
	}

    public void OnMove(InputAction.CallbackContext context)
    {
		moveInput = context.ReadValue<Vector2>();

		if (!context.performed) return;
	}

	public bool IsGrounded()
	{
		Vector2 rayDirection = isGravityFlipped? Vector2.up : Vector2.down;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayLength, groundLayer);
		Debug.DrawRay(transform.position, rayDirection * rayLength, hit.collider != null ? Color.green : Color.red);

		return hit.collider != null;
	}

	private void FlipGravity()
    {
		isGravityFlipped = !isGravityFlipped;

		float flipAngle = isGravityFlipped? 180f : 0f;

        rb.gravityScale *= -1;
	}

	private bool IsMoving()
	{
		if (moveInput.x != 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
