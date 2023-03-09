using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCartTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D cartRB;
    [SerializeField] private Rigidbody2D playerRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRB.transform.parent = null;
            playerRB.isKinematic = false;
            RotatePlayer();
        }
    }

    private void RotatePlayer()
    {
        playerRB.freezeRotation = false;
        playerRB.transform.rotation = new Quaternion(0, 0, 0, 0);
        playerRB.freezeRotation = true;
    }

}

