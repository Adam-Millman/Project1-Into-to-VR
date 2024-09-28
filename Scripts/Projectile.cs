using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed = 20f;  // Speed of the projectile
    public float lifetime = 5f;  // How long the projectile exists before it is destroyed

    private Rigidbody rb;  // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component on the projectile
        rb = GetComponent<Rigidbody>();

        // Move the projectile forward based on its speed
        rb.velocity = transform.forward * speed;

        // Destroy the projectile after a certain amount of time
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // You can add logic here to handle what happens when the projectile hits something
        // For example, if it hits the player or an enemy, you can apply damage or trigger events

        // Destroy the projectile on collision
        Destroy(gameObject);
    }
}
