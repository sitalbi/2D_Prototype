using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueObject dialogueData;

    private DialogueUI dialogueUI;
    private bool isInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);

        dialogueUI = dialogueBox.GetComponent<DialogueUI>();
    }

    private void Update() {
        if (isInRange && !dialogueBox.activeSelf) {
            if (Input.GetKeyDown(KeyCode.C)) {
                dialogueUI.ShowDialogue(dialogueData);
            }
        }
    }

    public void PlayerInRange() {
        canvas.gameObject.SetActive(true);
        isInRange = true;
    }
    
    public void PlayerExitRange() {
        canvas.gameObject.SetActive(false);
        isInRange = false;
    }
}
