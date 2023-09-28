using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorCounterView : MonoBehaviour
{
    [SerializeField] private ScorCounter _scorCounter;
    [SerializeField] private TextMeshProUGUI _points;

    private void Awake()
    {
        _scorCounter.OnChangedPoints += points =>
        {
            UpdateUI();
        };

        UpdateUI();
    }

    private void UpdateUI()
    {
        _points.text = _scorCounter.GetPoint().ToString();
    }
}
