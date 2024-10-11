using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public GameObject player;

    private float nextFireTime = 0f;
    private Transform playerCameraTransform;

    void Start()
    {
        nextFireTime = Time.time;
        playerCameraTransform = Camera.main.transform; 
    }

    void Update()
    {
        if (player != null && HasLineOfSight())
        {
            transform.LookAt(player.transform.position);
    
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        GameObject gameManager = GameObject.Find("GameManager");

    }

    void Shoot()
    {
        Debug.Log("Shooter is shooting!");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.shooter = gameObject;
        }
    }

    private bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = playerCameraTransform.position - transform.position;

        if (Physics.Raycast(transform.position, directionToPlayer, out hit))
        {
            if (hit.transform == playerCameraTransform)
            {
                return true;
            }
        }

        return false;
    }
}

