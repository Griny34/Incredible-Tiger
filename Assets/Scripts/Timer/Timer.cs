using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int _lifeTime;
    private Coroutine _tickCoroutine;

    public event Action OnStarted;
    public event Action<int> OnTick;
    public event Action OnFinished;

    public void StartTimer(int seconds)
    {
        _lifeTime = seconds;

        if (_tickCoroutine != null)
        {
            StopTimer();
        }

        _tickCoroutine = StartCoroutine(TickCoroutine());
        OnStarted?.Invoke();
    }

    public void StopTimer()
    {
        StopCoroutine(_tickCoroutine);
    }

    private IEnumerator TickCoroutine()
    {
        while (_lifeTime >= 1)
        {
            _lifeTime--;
            OnTick?.Invoke(_lifeTime);
            yield return new WaitForSeconds(1f);
        }

        OnFinished?.Invoke();
    }
}
