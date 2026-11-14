using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 2f;

    private float lifeTimer;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        lifeTimer = lifeTime;
        rb.linearVelocity = transform.up * speed;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0f)
        {
            BulletPool.Instance.ReturnBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.activeSelf) return;

        if (other.CompareTag("Player"))
        {
            if (!gameObject.activeSelf) return;
            BulletPool.Instance.ReturnBullet(this);
            GameEvents.PlayerDie();
        }
    }
}
