using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private AudioClip gameOverClip;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            sr.enabled = false;
            GameEvents.GameOver();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            sr.enabled = false;
            GameEvents.GameOver();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        }
    }
}
