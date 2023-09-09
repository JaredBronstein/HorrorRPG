using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO-DO: Add additional overrides for Interact in the child classes!
public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private string dialogueText;

    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public virtual void Interact()
    {
        StartCoroutine(inventoryManager.HandleInteractiveObject(dialogueText));
    }
}
