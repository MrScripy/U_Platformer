using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBox : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Destroy(collision.gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
