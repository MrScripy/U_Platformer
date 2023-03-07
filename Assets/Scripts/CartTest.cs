using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartTest : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private WheelJoint2D wheelJoint;
    [SerializeField] private float speed = 10f;
    private JointMotor2D motorSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.SetParent(transform);
        //player.GetComponent<Rigidbody2D>().mass = 3;
        motorSpeed.motorSpeed = speed;
        wheelJoint.motor = motorSpeed;
        wheelJoint.useMotor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.parent = null;
        //player.GetComponent<Rigidbody2D>().mass = 1;
    }


}
