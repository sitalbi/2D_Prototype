using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public virtual void Collect(PlayerLife playerLife) {
        gameObject.SetActive(false);
        Destroy(gameObject,5f);
    }
}
