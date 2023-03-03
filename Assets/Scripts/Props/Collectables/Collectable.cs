using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    public virtual void Collect() {
        gameObject.SetActive(false);
        Destroy(gameObject,2f);
    }
}
