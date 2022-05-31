using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{

    [SerializeField] private int typingSpeed;
    public Coroutine Run(string textToType, TMP_Text textLabel) {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel) {
        float time = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length) {
            time += Time.unscaledDeltaTime * typingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);
            
            yield return null;
        }

        textLabel.text = textToType;
    }
}
