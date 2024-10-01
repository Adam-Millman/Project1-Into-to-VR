using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;
    // 0100100
    // default telepport ...
    [SerializeField]
    private InputActionReference teleportButtonPress;

    void Start()
    {
        teleportButtonPress.action.performed += DoRaycast;
    }

    void DoRaycast(InputAction.CallbackContext __)
    {
        RaycastHit hit;

        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask);
        if (didHit)
        {
            playerOrigin.transform.position = hit.collider.gameObject.transform.position;
        }
    }
}