using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    private Vector3 direction;

    private void FixedUpdate()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction+=transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
        }
        Move();
    }

    private void Move()
    {
        Vector3 normalize = direction.normalized;
        playerRigidbody.linearVelocity = new Vector3(normalize.x*speed, playerRigidbody.linearVelocity.y, normalize.z*speed);
    }
}