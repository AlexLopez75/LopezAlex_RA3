using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    [SerializeField] private AudioClip pauseClip;

    [SerializeField] public GameObject pauseMenu;
    public bool isPaused;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
        SoundManager.Instance.PlaySound(SoundManager.Instance.pauseGame);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        SoundManager.Instance.PlaySound(SoundManager.Instance.pauseGame);
    }
}
