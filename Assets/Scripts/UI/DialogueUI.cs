using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject panel;

    private TypeWriterEffect typeWriterEffect;

    private void Start() {
        textLabel.color = Color.black;
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject) {
        Time.timeScale = 0f;
        panel.SetActive(true);
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject) {
        yield return new WaitForSecondsRealtime(1);
        foreach (string dialogue in dialogueObject.Dialogue) {
            yield return typeWriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.C));
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox() {
        Time.timeScale = 1f;
        panel.SetActive(false);
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
