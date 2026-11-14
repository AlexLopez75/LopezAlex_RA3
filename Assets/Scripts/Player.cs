using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            sr.enabled = false;
            Time.timeScale = 0;
            GameEvents.PlayerDie();
        }
    }
}
