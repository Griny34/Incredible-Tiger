using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class BonusActivator : MonoBehaviour
{
    [SerializeField] private Barrier _barrier;
    [SerializeField] private float _timeWorkButtonCat;
    [SerializeField] private ButtonActivator _buttonActivator;

    private Coroutine _coroutineBarrier;
    private Coroutine _coroutineSlowTime;

    public void StartPlayBarrier()
    {
        ScorCounter.Instance.GivePoints(_buttonActivator.CostBarrier);

        if (_coroutineBarrier != null)
        {
            StopCoroutine(_coroutineBarrier);
        }

        _coroutineBarrier = StartCoroutine(WorkBarrier(_barrier.LifeTime));
    }

    public void StartSlowTime()
    {
        ScorCounter.Instance.GivePoints(_buttonActivator.CostSpeedSlow);

        if (_coroutineSlowTime != null)
        {
            StopCoroutine(_coroutineSlowTime);
        }

        _coroutineSlowTime = StartCoroutine(WorkCat(_timeWorkButtonCat));
    }

    private IEnumerator WorkBarrier(float lifeTime)
    {
        _barrier.gameObject.SetActive(true);
        yield return new WaitForSeconds(lifeTime);
        _barrier.gameObject.SetActive(false);
    }

    private IEnumerator WorkCat(float lifeTime)
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(lifeTime);
        Time.timeScale = 1;
    }
}
