using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject settings;

    void Start()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
        settings.SetActive(false);
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

    public void OnSettingsButtonClick()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        Start();
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

}
