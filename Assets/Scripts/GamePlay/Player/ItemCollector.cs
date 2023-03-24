using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private CoinsManager coinsManager;
    [SerializeField] private ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CollectableItem"))
        {
            coinsManager.AddCoin(collision.transform.position, collision.GetComponent<Item>().ItemType);
            Destroy(collision.gameObject);
            Instantiate(particles, collision.transform.position, Quaternion.identity);
        }
            
    }
}
