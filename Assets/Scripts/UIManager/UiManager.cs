using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public bool IsGameOver { get; private set; }

    public void OnEnable()
    {
        GameEvents.OnGameOver += GameOver;
    }

    public void OnDisable()
    {
        GameEvents.OnGameOver -= GameOver;
    }

    private void GameOver()
    {
        IsGameOver = true;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
