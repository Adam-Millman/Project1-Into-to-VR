using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDelete : MonoBehaviour
{
    public void OnCollisionEnter(Collision collison){
        Destroy(gameObject);

    }
}
