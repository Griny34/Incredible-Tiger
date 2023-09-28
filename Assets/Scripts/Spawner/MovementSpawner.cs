using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private Vector3 _targetPoint;
    private int _currentIndex;

    private void Start()
    {
        _targetPoint = _points[1].position;
    }

    private void FixedUpdate()
    {
        Move();
        ChangePosition();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
    }

    private void ChangePosition()
    {
        if(transform.position == _targetPoint)
        {
            ChangeIndex();
        }
    }

    private void ChangeIndex()
    {
        _currentIndex++;

        if(_currentIndex >= _points.Length)
        {
            _currentIndex = 0;
        }

        _targetPoint = _points[_currentIndex].position;
    }
}
