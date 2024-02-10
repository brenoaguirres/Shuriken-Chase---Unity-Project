using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEmphasis : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Color newColor;
    [SerializeField] private float newSize;
    [SerializeField] private float time;
    private Color originalColor;
    private float originalSize;

    private void Start() {
        originalColor = textComponent.color;
        originalSize = textComponent.fontSize;
    }

    public IEnumerator ChangeTextColor() {
        textComponent.color = newColor;
        textComponent.fontSize = newSize;
        yield return new WaitForSeconds(time);

        textComponent.color = originalColor;
        textComponent.fontSize = originalSize;
    }
}
