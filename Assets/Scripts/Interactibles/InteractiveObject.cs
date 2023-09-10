using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected string dialogueText;

    [SerializeField]
    protected bool removeOnInteract;

    protected InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public virtual void Interact()
    {
        StartCoroutine(inventoryManager.HandleInteractiveObject(this, removeOnInteract, dialogueText));
    }
}
