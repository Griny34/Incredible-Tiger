using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _textTimer;

    private void Awake()
    {
        _timer.OnTick += seconds =>
        {
            UpdateUI(seconds);
        };
    }

    private void UpdateUI(int sec)
    {
        _textTimer.text = ParseTime(sec);
    }

    private string ParseTime(int sec)
    {
        string number = "";
        int minutes = sec / 60;
        int seconds = sec % 60;

        if(minutes < 10)
        {
            number += "0";
        }

        number += minutes + ":";

        if(seconds < 10)
        {
            number += "0";
        }

        number += seconds;

        return number;
    }
}
