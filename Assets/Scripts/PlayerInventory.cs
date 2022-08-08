using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInventory : MonoBehaviour
{
    //ListForParts
    [SerializeField] public List<GameObject> _bridgeParts;

    //ForCollectedItems
    [SerializeField] private float _itemSpeed;
    private float _offsetY = 3;
    private Vector3 _movePointForBridgePart;

    private void Start()
    {
        _movePointForBridgePart = Vector3.zero;
        _bridgeParts = new List<GameObject>();
        ItemCollector.OnItemCollected += AddItemToInventory;
    }

    private void Update()
    {
        
    }

    private void AddItemToInventory(GameObject obj)
    {
        obj.transform.parent = transform;
        obj.transform.forward = transform.forward;
        obj.transform.DOLocalMove(_movePointForBridgePart, _itemSpeed).OnComplete(() =>
        {
            _bridgeParts.Add(obj);
        });
        _movePointForBridgePart.y += _offsetY;
    }

    public GameObject GetItemToInventory()
    {
        if (_bridgeParts.Count == 0) return null;
        GameObject obj = _bridgeParts[_bridgeParts.Count - 1];
        _bridgeParts.Remove(obj);
        return obj;
    }

}
