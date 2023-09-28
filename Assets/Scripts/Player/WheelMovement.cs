using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WheelMovement : MonoBehaviour
{
    public static WheelMovement Instance { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _angleRotation;

    private Coroutine _coroutine;
    private float _rotate;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;       
    }

    private void Start()
    {
        _rotate = transform.rotation.eulerAngles.z;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, _rotate), _speed * Time.deltaTime);
    }

    public void MoveClockWise()
    {
        _rotate -= _angleRotation;
    }

    public void MoveContrClockWise()
    {
        _rotate += _angleRotation;
    }

    public void SlowdownWheel(float time, int slowdown)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(CountingTime(time, slowdown));
    }

    private IEnumerator CountingTime(float time, int slowdown)
    {
        _speed -= slowdown;

        yield return new WaitForSeconds(time);

        _speed += slowdown;
    }
}
