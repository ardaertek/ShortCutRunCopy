using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ItemCollector : MonoBehaviour
{
    public static event Action<GameObject> OnItemCollected;
    private void OnTriggerEnter(Collider other)
    {
        OnItemCollected?.Invoke(other.gameObject);
    }
}
