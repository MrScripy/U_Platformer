using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerChar : Character
{
    [SerializeField] private PlayerMovement move;
    [SerializeField] private GameObject deadCanvas;

    private void Start()
    {
        deadCanvas.SetActive(false);
    }
    void Update()
    {
        move.PlayerMove();
    }
    public override void Death()
    {
        Time.timeScale = 0;
        deadCanvas.SetActive(true);
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
