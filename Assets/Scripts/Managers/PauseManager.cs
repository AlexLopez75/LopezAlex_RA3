using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    [SerializeField] private AudioClip pauseClip;

    [SerializeField] public GameObject pauseMenu;
    private PlayerMove pm;
    public bool isPaused;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        //Desactivated cause it breaks exit of pause menu
        //pm.enabled = false;
        pauseMenu.SetActive(true);
        isPaused = true;
        SoundManager.Instance.PauseMusic();
        SoundManager.Instance.PlaySound(SoundManager.Instance.pauseGame);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        //Desactivated cause it breaks exit of pause menu
        //pm.enabled = true;
        pauseMenu.SetActive(false);
        isPaused = false;
        SoundManager.Instance.PlaySound(SoundManager.Instance.pauseGame);
        SoundManager.Instance.ResumeMusic();
    }
}
