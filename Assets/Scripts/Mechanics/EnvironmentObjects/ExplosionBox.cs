using UnityEngine;

public class ExplosionBox : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject explosionBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosionBox.SetActive(false);
        }
    }
}
