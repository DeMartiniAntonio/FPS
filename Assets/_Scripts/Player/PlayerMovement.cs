using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    private Vector3 direction;
    private bool isGrounded;
    [SerializeField] private Vector3 jumpForce = new Vector3(0, 25, 0);
    private float nextDamageTime = 0f;

    private void Update()
    {
        if(!isGrounded)
        {
            playerRigidbody.AddForce(Physics.gravity - new Vector3(0, -2, 0 ));

            return;
        }
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
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 normalize = direction.normalized;
        playerRigidbody.linearVelocity = new Vector3(normalize.x*speed, playerRigidbody.linearVelocity.y, normalize.z*speed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out TerrainCollider teren))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out TerrainCollider teren))
        {
            isGrounded = false;
            
            Debug.Log("Not Grounded");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FireDetect fire))
        {
            speed -= 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.TryGetComponent(out FireDetect fire))
        {
            speed += 2;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Fire fire = gameObject.GetComponent<Fire>();
        Health healt = gameObject.GetComponent<Health>();
        if (other.gameObject.TryGetComponent(out FireDetect fireDetect))
        {
            if (Time.time >= nextDamageTime)
            {
                healt.TakeDamage(fire.damage);
                nextDamageTime = Time.time + 1f;

            }
        }
        }

    }

