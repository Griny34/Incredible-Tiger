using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Match 1", menuName = "ScriptableObjects/Match", order = 0)]
public class MatchModelSO : ScriptableObject
{
    [SerializeField] private int _numberLevel;
    [SerializeField] private int _timeLevel;

    public int NumberLevel => _numberLevel;
    public int TimeLevel => _timeLevel;
}
