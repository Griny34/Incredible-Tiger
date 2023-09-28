using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchModel : MonoBehaviour
{
    public static MatchModel Instace { get; private set; }

    [SerializeField] private int _longTimer;
    [SerializeField] private Timer _timer;
    [SerializeField] private Image _menuPause;
    [SerializeField] private Image _menuFinish;

    public event Action OnChangeMatch;

    private void Awake()
    {
        if(Instace != null)
        {
            Destroy(gameObject);
            return;
        }

        Instace = this;
    }

    private void Start()
    {
        Initialize();

        AudioManager.Instance.PlaySound($"Background");

        _timer.OnFinished += () =>
        {
            FinishMatch();
        };
    }

    private void Initialize()
    {
        _timer.StartTimer(_longTimer);
        OnChangeMatch?.Invoke();
    }

    public void StartNextMatch()
    {
        int currentIndexScen = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIndexScen + 1);

        Time.timeScale = 1;
    }

    public void FinishMatch()
    {
        Time.timeScale = 0;

        _menuFinish.gameObject.SetActive(true);
    }
}
