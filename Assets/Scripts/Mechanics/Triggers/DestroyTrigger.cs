using UnityEngine;

// destroys interactable and other objects. Don't use for player (use DeathTrigger)
public class DestroyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject);
    }
}
