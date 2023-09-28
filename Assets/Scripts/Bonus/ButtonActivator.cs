using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] private int _costBarrier;
    [SerializeField] private Image _backgroundBattonBarrier;
    [SerializeField] private GameObject _barrierButton;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUIBarrier;
    [SerializeField] private Image _moneyBarrier;

    [SerializeField] private int _costSpeedSlow;
    [SerializeField] private Image _backgroundBattonSlow;
    [SerializeField] private GameObject _barrierSlowButton;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUISlow;
    [SerializeField] private Image _moneySlowButton;

    private Color _colorButtonBarrier;
    private Color _colorSpeedSlow;
    private float _alphaValueOff = 0.4f;
    private float _alphaValueOn = 1f;

    public int CostBarrier => _costBarrier;
    public int CostSpeedSlow => _costSpeedSlow;


    private void Awake()
    {
        _backgroundBattonBarrier.color = new Color(1, 1, 1, _alphaValueOff);
        _colorButtonBarrier = _barrierButton.GetComponent<Button>().colors.normalColor;
        _colorButtonBarrier.a = _alphaValueOff;
        _textMeshProUGUIBarrier.color = new Color(1, 1, 1, _alphaValueOff);
        _moneyBarrier.color = new Color(1, 1, 1, _alphaValueOff);

        _backgroundBattonSlow.color = new Color(1, 1, 1, _alphaValueOff);
        _colorSpeedSlow = _barrierSlowButton.GetComponent<Button>().colors.normalColor;
        _colorSpeedSlow.a = _alphaValueOff;
        _textMeshProUGUISlow.color = new Color(1, 1, 1, _alphaValueOff);
        _moneySlowButton.color = new Color(1, 1, 1, _alphaValueOff);

        _barrierButton.transform.GetComponent<Button>().interactable = false;
        _barrierSlowButton.GetComponent<Button>().interactable = false;
    }

    private void Start()
    {
        ScorCounter.Instance.OnChangedPoints += points =>
        {
            if (ScorCounter.Instance.GetPoint() >= _costBarrier)
            {
                _backgroundBattonBarrier.color = new Color(1, 1, 1, _alphaValueOn);
                _colorButtonBarrier.a = _alphaValueOn;
                _textMeshProUGUIBarrier.color = new Color(1,1,1, _alphaValueOn);
                _moneyBarrier.color = new Color(1, 1, 1, _alphaValueOn);

                _barrierButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                _backgroundBattonBarrier.color = new Color(1, 1, 1, _alphaValueOff);
                _colorButtonBarrier.a = _alphaValueOff;
                _textMeshProUGUIBarrier.color = new Color(1, 1, 1, _alphaValueOff);
                _moneyBarrier.color = new Color(1, 1, 1, _alphaValueOff);

                _barrierButton.transform.GetComponent<Button>().interactable = false;
            }

            if (ScorCounter.Instance.GetPoint() >= _costSpeedSlow)
            {
                _backgroundBattonSlow.color = new Color(1, 1, 1, _alphaValueOn);
                _colorSpeedSlow.a = _alphaValueOn;
                _textMeshProUGUISlow.color = new Color(1, 1, 1, _alphaValueOn);
                _moneySlowButton.color = new Color(1, 1, 1, _alphaValueOn);

                _barrierSlowButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                _backgroundBattonSlow.color = new Color(1, 1, 1, _alphaValueOff);
                _colorSpeedSlow.a = _alphaValueOff;
                _textMeshProUGUISlow.color = new Color(1, 1, 1, _alphaValueOff);
                _moneySlowButton.color = new Color(1, 1, 1, _alphaValueOff);

                _barrierSlowButton.GetComponent<Button>().interactable = false;
            }
        };
    }
}
