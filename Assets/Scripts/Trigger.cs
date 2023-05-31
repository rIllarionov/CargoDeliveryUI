using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private Transform _finishPossition;
    private BoxController _boxController;
    private Collider _boxCollider;

    private void Awake()
    {
        _boxController = _box.GetComponent<BoxController>();
        _boxCollider = _box.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other==_boxCollider)
        {
            _boxController.DropDown(_finishPossition.position);
        }
    }
}
