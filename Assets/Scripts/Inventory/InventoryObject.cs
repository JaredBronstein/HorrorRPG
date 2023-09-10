using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObject : MonoBehaviour
{
    [SerializeField]
    private int keyID;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string itemDescription;

    [SerializeField]
    private Image itemImage;

    public int getKeyID()
    { 
        return keyID; 
    }

    public string getItemInfo()
    {
        return itemName + "#" + itemDescription;
    }

    public Image getItemImage() 
    {
        return itemImage;
    }
}
