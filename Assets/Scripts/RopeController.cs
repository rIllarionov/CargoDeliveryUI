using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRendererPoints;
    [SerializeField] private float _moveSpeed;
    [field:SerializeField] public Transform _finishPoint { get; private set; }
    [SerializeField] private ScreenController _screenController;
    private bool _boxInAir;

    private Vector3 [] _wayPoints;

    private void Awake()
    {
        _boxInAir = true;
    }

    public void Move()
    {
        GetPoints();
        StartCoroutine(Moving());
    }

    private void GetPoints()//получаем массив координат для движения
    {
        _wayPoints = new Vector3[_lineRendererPoints.positionCount];
        _lineRendererPoints.GetPositions(_wayPoints);
    }

    private IEnumerator Moving()
    {
        for (int currentNextPoint = 0; currentNextPoint < _wayPoints.Length-1; currentNextPoint++)
        {

            while (transform.position!=_wayPoints[currentNextPoint])
            {
                transform.position = Vector3.MoveTowards(transform.position, _wayPoints[currentNextPoint], _moveSpeed*Time.deltaTime);
                yield return null;
            }
            
        }

        if (transform.position == _wayPoints[^1]&&_boxInAir)
        {
            MoveIsFinish(false);
        }
    }

    public void MoveIsFinish(bool isItFinish)
    {
        if (isItFinish)
        {
            _screenController.ActivateScreen(_screenController.WinnerScreen);
        }

        else
        {
            _screenController.ActivateScreen(_screenController.GameOverScreen);
        }
    }

    public void BoxOnTheGround()
    {
        _boxInAir = false;
    }

}
