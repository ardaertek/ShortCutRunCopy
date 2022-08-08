using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidbody : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        BridgeMaker.PlayerFalling += _setRigidbody;
    }

    private void _setRigidbody()
    {
        rb.useGravity = true;
    }
}
