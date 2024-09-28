using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 100f;
    private GameObject playerTarget;
    
    void Update()
    {
        // Only move forward when we have a player target
        if(playerTarget != null){
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * move_speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other){
        playerTarget = other.gameObject;
        		if (other.gameObject.tag == "Damage") {
	      string currentSceneName = SceneManager.GetActiveScene().name;
	      SceneManager.LoadScene(currentSceneName);
	  }
    }

}
