using UnityEngine;

namespace Props
{
    public class Sign : Interactable
    {
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private DialogueObject dialogueData;

        private DialogueUI dialogueUI;
    
        // Start is called before the first frame update
        void Start()
        {
            dialogueUI = dialogueBox.GetComponent<DialogueUI>();
        }

        protected override void Interact()
        {
            if (!dialogueBox.activeSelf)
            {
                dialogueUI.ShowDialogue(dialogueData);
            }
        }
    }
}