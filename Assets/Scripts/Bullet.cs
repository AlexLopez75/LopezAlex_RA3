using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private AudioClip gameOverClip;

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
            GameEvents.GameOver();
            BulletPool.Instance.ReturnBullet(this);
            SoundManager.Instance.PlaySound(gameOverClip);
        }
    }
}
