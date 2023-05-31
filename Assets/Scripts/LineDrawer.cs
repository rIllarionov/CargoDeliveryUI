using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [FormerlySerializedAs("_ropeMoover")] [SerializeField] private RopeController ropeController;
    private Vector3 _mousePossition;

    private void Awake()
    {
        _mousePossition = new Vector3();
    }
    
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            GetMousePosition();
            Drawing();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ropeController.Move();
        }
        
    }

    private void GetMousePosition()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out RaycastHit info))
        {
            _mousePossition = info.point;
            _mousePossition.z = -0.4f;
        }
        
    }

    private void Drawing()
    {
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1,_mousePossition);
    }
    
}
