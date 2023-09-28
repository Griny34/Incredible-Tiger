using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    
    [SerializeField] private int _startValue;
    [SerializeField] private GameObject _windowEnd;

    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;

            if(_value <= 0)
            {
                OnDeath?.Invoke();
                _value = 0;
            }

            OnChangeHealth?.Invoke(_value, _startValue);
        }
    }

    public int StartValue => _startValue;

    public event Action<int, int> OnChangeHealth;
    public event Action OnDeath;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;

        _value = _startValue;
    }

    private void Start()
    {
        OnDeath += () =>
        {
            Time.timeScale = 0;
            _windowEnd.SetActive(true);
        };
    }

    public void TakeDamag(int damag)
    {
        Value -= damag;
    }
}
