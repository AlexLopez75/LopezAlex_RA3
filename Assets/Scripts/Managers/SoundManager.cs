using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;
    private AudioSource soundEffectAudio;
    private AudioSource musicAudio;

    [SerializeField] public AudioClip gravityFlìp;
    [SerializeField] public AudioClip gameOver;
    [SerializeField] public AudioClip playerWin;
    [SerializeField] public AudioClip pauseGame;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if (source.clip != null)
            {
                musicAudio = source;
            }
            else if (soundEffectAudio == null)
            {
                soundEffectAudio = source;
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicAudio.Stop();
    }

    public void PauseMusic()
    {
        musicAudio.Pause();
    }

    public void ResumeMusic()
    {
        musicAudio.UnPause();
    }
}
