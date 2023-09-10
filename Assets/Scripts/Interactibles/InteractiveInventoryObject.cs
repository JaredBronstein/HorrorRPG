using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveInventoryObject : InteractiveObject
{
    [SerializeField]
    private InventoryObject inventoryObject;

    public override void Interact()
    {
        StartCoroutine(inventoryManager.HandleInteractiveObject(this, removeOnInteract, inventoryObject, dialogueText));
    }
}
