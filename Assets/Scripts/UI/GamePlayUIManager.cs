using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUIManager : MonoBehaviour
{
    [Header("Game Panels"), Space]
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gamePanel;
    [Header("Collectable Objects"), Space]
    [SerializeField] private Item[] collectableItems;
    [SerializeField] private TMP_Text totalCoinsAmount;
    [SerializeField] private TMP_Text collectedCoinsAmount;

    private int allCoins;

    private void Start()
    {
        CheckPanels();
        CountAllCoins();
    }

    private void CheckPanels()
    {
        deadPanel.SetActive(false);
        winPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void CountAllCoins()
    {
        for (int i = 0; i < collectableItems.Length; i++)
        {
            allCoins += (int)collectableItems[i].ItemType;
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

    public void OnNextLevelButtonClick()
    {
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
        collectedCoinsAmount.text = coinsAmount.ToString();

    }


}
