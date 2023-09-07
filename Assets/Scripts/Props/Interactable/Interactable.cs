using UnityEngine;
using UnityEngine.InputSystem;

namespace Props
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        
        private PlayerController playerController;
        private bool isInRange;
        
        public virtual void Start() {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            canvas.gameObject.SetActive(false);
        }

        private void Update() {
        }

        public virtual void Interact() {}
        
        public void PlayerInRange() {
            canvas.gameObject.SetActive(true);
            isInRange = true;
            playerController.SetInteractableObject(this);
        }
    
        public void PlayerExitRange() {
            canvas.gameObject.SetActive(false);
            isInRange = false;
            playerController.SetInteractableObject(null);
        }
    }
}