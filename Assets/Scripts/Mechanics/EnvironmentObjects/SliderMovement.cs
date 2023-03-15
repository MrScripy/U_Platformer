using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderMovement : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D speed;
    private Rigidbody2D platformRB;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        speed = slider.motor;
        platformRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            speed.motorSpeed = 3;
            slider.motor = speed;
        }
        else if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            speed.motorSpeed = -3;
            slider.motor = speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.transform.parent = transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.transform.parent = null;
    }
    
}
