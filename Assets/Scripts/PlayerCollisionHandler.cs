using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHitBox") || collision.gameObject.CompareTag("BulletHitBox"))
        {
            SceneManager.LoadScene("Scenes/GameOver");
            Debug.Log("You've Been hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHitBox") || other.gameObject.CompareTag("BulletHitBox"))
        {
            SceneManager.LoadScene("Scenes/GameOver");
            Debug.Log("You've Been hit");
        }
    }
}
