using UnityEngine;

namespace Props
{
    public class Sign : Interactable
    {
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private DialogueObject dialogueData;

        private DialogueUI dialogueUI;
    
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            dialogueUI = dialogueBox.GetComponent<DialogueUI>();
        }

        public override void Interact()
        {
            if (!dialogueBox.activeSelf)
            {
                dialogueUI.ShowDialogue(dialogueData);
            }
        }
    }
}