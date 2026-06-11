using System.Collections;
using UnityEngine;
using System;

public class UnlockItem : MonoBehaviour
{
 
    public GameObject itemToUnlock;
    
    public bool unlocked;

    public string itemTag = "Key";

    public event Action OnUnlock;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == itemTag)
        {
            unlocked = true;
            OnUnlock?.Invoke();

        }
    }

}

