using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorCounter : MonoBehaviour
{
    public static ScorCounter Instance { get; private set; }

    [SerializeField] private int _startPoints;

    private int _playerPoints;

    public event Action<int> OnChangedPoints;    

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public int GetPoint()
    {
        return _playerPoints;
    }

    public void TakePoints(int points)
    {
        _playerPoints += points;

        OnChangedPoints?.Invoke(points);
    }

    public void GivePoints(int points)
    {
        if (_playerPoints < points) return;

        _playerPoints -= points;

        OnChangedPoints?.Invoke(points);
    }

    private void Start()
    {
        _playerPoints = _startPoints;
    }
}
