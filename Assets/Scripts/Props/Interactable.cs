using UnityEngine;

namespace Props
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        private bool isInRange;
        
        void Start()
        {
            canvas.gameObject.SetActive(false);
        }

        private void Update() {
            if (isInRange) {
                if (Input.GetKeyDown(KeyCode.C)) {
                    Interact();
                }
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