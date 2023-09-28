using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;    

    private void Start()
    {
        Health.Instance.OnChangeHealth += (value, _value) =>
        {
            _slider.value = value;
        };
    }
}
