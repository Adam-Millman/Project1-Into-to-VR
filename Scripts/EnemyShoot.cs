using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f; 
    public GameObject player;

    private float nextFireTime = 0f;

    void Start()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
    
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
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
}
