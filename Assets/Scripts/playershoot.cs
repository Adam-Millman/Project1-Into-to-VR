using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playershoot : MonoBehaviour
{
    
    public GameObject ProjectileTemplate;
    public float shootPower = 1000f;
    public InputActionReference trigger;

    void Start()
    {
        trigger.action.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext _)
    {
        GameObject newProjectile = Instantiate(ProjectileTemplate, transform.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }
}
