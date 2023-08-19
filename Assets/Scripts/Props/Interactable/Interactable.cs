using UnityEngine;
using UnityEngine.InputSystem;

namespace Props
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        private bool isInRange;
        
        public virtual void Start()
        {
            canvas.gameObject.SetActive(false);
        }

        private void Update() {
            /*if (isInRange) {
                if (Input.GetKeyDown(KeyCode.C)) {
                    Interact();
                }
            }*/
        }

        public void OnActionInput(InputAction.CallbackContext context) {
            if (context.started && isInRange) {
                Interact();
            }
        }

        protected virtual void Interact() {}
        
        public void PlayerInRange() {
            canvas.gameObject.SetActive(true);
            isInRange = true;
        }
    
        public void PlayerExitRange() {
            canvas.gameObject.SetActive(false);
            isInRange = false;
        }
    }
}