using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveLockedObject : InteractiveObject
{
    [SerializeField]
    private string failText;

    [SerializeField]
    private int lockID;

    [SerializeField]
    [Tooltip("Note: This does NOTHING besides allow you to track what the name of the key object is for the sake of debugging.")]
    private string lockName;

    public override void Interact()
    {
        StartCoroutine(inventoryManager.HandleInteractiveObject(this, removeOnInteract, dialogueText, failText, lockID));
    }
}
