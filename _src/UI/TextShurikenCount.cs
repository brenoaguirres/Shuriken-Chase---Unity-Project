using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextShurikenCount : MonoBehaviour
{
    private TMP_Text _textComponent;
    [SerializeField] private Ammunition _ammunition;
    private string _ammoString;
    private string _previousAmmoString;
    private TextEmphasis _txtEmphasis;

    void Start()
    {
        _textComponent = GetComponent<TMP_Text>();
        _txtEmphasis = GetComponent<TextEmphasis>();
        UpdateText("x 10");
        _previousAmmoString = _ammunition.GetAmmoCount().ToString();
    }

    void Update()
    {
        _ammoString = _ammunition.GetAmmoCount().ToString();
        if (_ammoString != _previousAmmoString) {
            _previousAmmoString = _ammoString;
            UpdateText("x " + _ammoString);
            StartCoroutine(_txtEmphasis.ChangeTextColor());
        }
    }

    private void UpdateText(string newText) {
        _textComponent.text = newText;
    }
}
