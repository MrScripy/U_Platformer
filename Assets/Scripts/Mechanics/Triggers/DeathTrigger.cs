using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GamePlayUIManager gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            gameUI.PlayerDie();
    }
}
