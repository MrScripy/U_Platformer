using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUIManager : MonoBehaviour
{
    [Header("Game Panels"), Space]
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainPausePanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Collectable Objects"), Space]
    [SerializeField] private GameObject[] collectableItems;
    [SerializeField] private TMP_Text totalCoinsAmount;
    [SerializeField] private TMP_Text collectedCoinsAmount;

    private int allCoins;
    private bool isPaused = false;

    private void Start()
    {
        allCoins = 0;
        CheckPanels();
        CountAllCoins();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void CheckPanels()
    {
        gamePanel.SetActive(true);
        deadPanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void CountAllCoins()
    {
        if (collectableItems != null)
        {
            for (int i = 0; i < collectableItems.Length; i++)
            {
                if (collectableItems[i].TryGetComponent<Item>(out Item item))
                    allCoins += (int)item.ItemType;
            }
        }
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnSettingsButtonClick()
    {
        mainPausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnNextLevelButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerDie()
    {
        Time.timeScale = 0;
        deadPanel.SetActive(true);
    }

    public void PlayerWin(int coinsAmount)
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        totalCoinsAmount.text = allCoins.ToString();
        collectedCoinsAmount.text = coinsAmount.ToString();
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        mainPausePanel.SetActive(true);
        settingsPanel.SetActive(false);
        isPaused = true;
    }

    public void OnBackButtonClick()
    {
        pausePanel.SetActive(true);
        mainPausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
