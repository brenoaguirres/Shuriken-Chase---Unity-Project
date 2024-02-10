using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText : MonoBehaviour
{
    private TMP_Text _textComponent;
    [SerializeField] private MeterCounter _meterCounter;
    private string _meterString;

    void Start()
    {
        _textComponent = GetComponent<TMP_Text>();
        UpdateText("0 m");
    }

    void Update()
    {
        _meterString = _meterCounter.GetMetersString();
        UpdateText(_meterString);
    }

    private void UpdateText(string newText) {
        _textComponent.text = newText;
    }
}
