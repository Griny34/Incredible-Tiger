using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchModelView : MonoBehaviour
{
    [SerializeField] private MatchModel _matchModel;
    [SerializeField] private TextMeshProUGUI _numberMatch;
    [SerializeField] private TextMeshProUGUI _playerProgress;

    private void Awake()
    {
        _matchModel.OnChangeMatch += () =>
        {
            _numberMatch.text = SceneManager.GetActiveScene().buildIndex.ToString();
        };
    }

    private void Start()
    {
        ScorCounter.Instance.OnChangedPoints += value =>
        {
            UpdateUI(_playerProgress.text, ScorCounter.Instance.GetPoint());
        };
    }

    private void UpdateUI(string text, int number)
    {
        text = number.ToString();
    }
}
