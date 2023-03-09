using UnityEngine;

public class CartTest : MonoBehaviour
{
    [SerializeField] private GameObject triggerField;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cart;
    [SerializeField] private Rigidbody2D playerRB;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.parent = cart.transform;
            RotatePlayer();
            playerRB.isKinematic = true;
            triggerField.SetActive(false);
        }
    }
    private void RotatePlayer()
    {
        playerRB.freezeRotation = false;
        playerRB.transform.rotation = new Quaternion(0, 0, 0, 0);
        playerRB.freezeRotation = true;
    }
}
