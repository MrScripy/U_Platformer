using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    //[SerializeField] private PlayerChar player;
    //[SerializeField] int sceneNumber;
    [SerializeField] private GamePlayUIManager gameUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            gameUI.PlayerDie();
    }
}
