using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject canva;
    
    // Start is called before the first frame update
    void Start()
    {
        canva.gameObject.SetActive(false);
    }

    public void PlayerInRange() {
        canva.gameObject.SetActive(true);
    }
    
    public void PlayerExitRange() {
        canva.gameObject.SetActive(false);
    }
}
