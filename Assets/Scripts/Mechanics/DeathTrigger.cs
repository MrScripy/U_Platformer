using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private PlayerChar player;
    [SerializeField] int sceneNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            player.Death();
    }
}
