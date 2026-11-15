using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public float speed = 4f;
    public int direction = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("WallHit");
            direction *= -1;
            sr.flipX = !sr.flipX; 
        }
    }
}
