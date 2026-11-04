using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour, InputSystem_Actions.IControllerActions
{
	// Editor references
	[SerializeField] private float rayLength = 0.6f;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private float speed;

	// GameObject components
	private Rigidbody2D rb;

	// Private variables
	private bool gravityFlipped;
	private Vector2 moveInput;
	private float gravityInput;

	// Other
	private InputSystem_Actions inputActions;

	private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Controller.SetCallbacks(this);
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
		transform.Translate(moveInput * speed * Time.deltaTime);
	}

	public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
			gravityInput = context.ReadValue<float>();
			bool grounded = IsGrounded();

            if (grounded)
            {
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
        Vector2 raycastDirection = gravityFlipped ? Vector2.up : Vector2.down;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, rayLength, groundLayer);
		Debug.DrawRay(transform.position, raycastDirection * rayLength, hit.collider != null ? Color.green : Color.red);

		return hit.collider != null;
	}

	private void FlipGravity()
    {
        gravityFlipped = !gravityFlipped;

        rb.gravityScale *= gravityFlipped? -1 : 1;
    }
}
