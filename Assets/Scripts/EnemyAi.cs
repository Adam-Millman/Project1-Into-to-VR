using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 100f;
    private GameObject playerTarget;
    private Transform playerCameraTransform;

    void Start()
    {
        playerCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if(playerTarget != null && HasLineOfSight())
        {
            transform.LookAt(playerCameraTransform.position);
            transform.position += transform.forward * move_speed * Time.deltaTime;
        }
        GameObject gameManager = GameObject.Find("GameManager");

    }

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
        if (other.gameObject.tag == "Damage")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = playerCameraTransform.position - transform.position;
        
        if(Physics.Raycast(transform.position, directionToPlayer, out hit))
        {
            if(hit.transform == playerCameraTransform)
            {
                return true;
            }
        }

        return false;
    }
}

