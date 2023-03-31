using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levels;
    void Start()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
    }

    public void OnPlayButtonClick()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
    }

    public void OnLevelButtonClick(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnBackButtonClick()
    {
        Start();
    }


}
