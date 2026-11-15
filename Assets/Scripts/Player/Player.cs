using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerMove pm;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        pm = FindAnyObjectByType<PlayerMove>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            sr.enabled = false;
            pm.enabled = false;
            GameEvents.GameOver();
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        }
        else if (other.CompareTag("Exit"))
        {
            pm.enabled = false;
            GameEvents.GameOver();
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlaySound(SoundManager.Instance.playerWin);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            sr.enabled = false;
            pm.enabled = false;
            GameEvents.GameOver();
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        }
    }
}
