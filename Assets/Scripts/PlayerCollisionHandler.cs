using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    public string gameOverSceneName = "Scene/GameOver";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyhitbox") || collision.gameObject.CompareTag("bullethitbox"))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyhitbox") || other.gameObject.CompareTag("bullethitbox"))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
