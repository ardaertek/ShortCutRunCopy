using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //Character Always Going Forward You Move Him With Rotation(Transform Forward)
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _forwardMovementSpeed;
    [SerializeField] private Transform _lookPoint; //In front of the character
    private Vector3 _forwardMove;
    void Update()
    {

        //RunFront
        _forwardMove = _lookPoint.position - transform.position;
        transform.position += _forwardMove * Time.deltaTime * _forwardMovementSpeed;

        //Left And Right Controller
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.Rotate(0, (-1)  * _movementSpeed, 0);
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                transform.Rotate(0,  _movementSpeed, 0);
            }
            else
            {
                var rotation = Quaternion.LookRotation(_lookPoint.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            }
        }
    }
}
