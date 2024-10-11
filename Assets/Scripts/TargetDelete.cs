using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetDelete : MonoBehaviour
{
    public static int totalEnemies = 0;
    public static int killCount = 0;

    public string nextSceneName;

    void Start()
    {
        if (totalEnemies == 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            totalEnemies = enemies.Length;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        killCount++;

        Destroy(gameObject);

        if (killCount >= totalEnemies)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
