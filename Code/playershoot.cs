using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playershoot : MonoBehaviour
{
    
    public GameObject ProjectileTemplate;
    public float shootPower = 10000000f;
    public InputActionReference trigger;
    // Start is called before the first frame update
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
