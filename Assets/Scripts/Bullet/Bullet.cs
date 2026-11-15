using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private AudioClip gameOverClip;

    private float lifeTimer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerMove pm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pm = FindAnyObjectByType<PlayerMove>();
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
            sr.enabled = false;
            pm.enabled = false;
            GameEvents.GameOver();
            BulletPool.Instance.ReturnBullet(this);
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlaySound(gameOverClip);
        }
    }
}
