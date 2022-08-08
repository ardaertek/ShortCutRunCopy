using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BridgeMaker : MonoBehaviour
{
    //ForFalling
    public static event Action PlayerFalling;

    //ForRay
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private LayerMask _rayLayer;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private Transform _bridgePartPoint;
    [SerializeField] private GameObject _bridges;
    bool _canDoBridge = true;
    private void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, transform.forward, 3f, _rayLayer))
        {
            if (_canDoBridge)
            {
                _canDoBridge = false;
                GameObject obj = _inventory.GetItemToInventory();
                if (obj != null)
                {
                    obj.transform.parent = _bridges.transform;
                    obj.layer = LayerMask.NameToLayer("BridgePart");
                    obj.transform.position = _bridgePartPoint.position;
                    obj.transform.DOLocalMove(_bridgePartPoint.position, 0.05f).OnComplete(() =>
                    {
                        _canDoBridge = true;
                    });
                }
                else
                {
                    PlayerFalling?.Invoke();
                }
            }
        }
    }

}
