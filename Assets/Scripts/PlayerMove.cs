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

	// Private variables
	private bool isGravityFlipped;
	private Vector2 moveInput;
	private bool grounded = true;

	// Other
	private InputSystem_Actions inputActions;

	private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Controller.SetCallbacks(this);
		rb = GetComponent<Rigidbody2D>();
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
		grounded = IsGrounded();



		rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
	}

	public void OnJump(InputAction.CallbackContext context)
    {
		if (context.performed)
		{
            if (grounded)
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
		transform.localRotation = Quaternion.Euler(0, 0f, flipAngle);
		transform.localRotation = Quaternion.Euler(flipAngle, 0f, 0f);
	}
}
