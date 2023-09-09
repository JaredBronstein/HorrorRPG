using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    [SerializeField]
    private int keyID;

    public int getKeyID()
    { 
        return keyID; 
    }
}
