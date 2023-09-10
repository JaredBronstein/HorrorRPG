using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private float dialogueDelay = 1.5f;

    private Canvas UI;
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;
    private List<InventoryObject> inventory = new List<InventoryObject>();

    private void Awake()
    {
        UI = FindAnyObjectByType<Canvas>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerInteraction = FindFirstObjectByType<PlayerInteraction>();
        UI.enabled = false;
    }

    #region HandlingInteractiveObjects
    /// <summary>
    /// If you interact with a "locked" object that gives an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InteractiveObject interactiveObject, bool isRemoved, InventoryObject inventoryObject, string successText, string failText, int ObjectID)
    {
        if (hasItem(ObjectID))
        {
            AddObject(inventoryObject);
            EnableText(successText);
            yield return new WaitForSeconds(dialogueDelay);
            if(isRemoved)
                interactiveObject.gameObject.SetActive(false);
        }
        else
        {
            EnableText(failText);
            yield return new WaitForSeconds(dialogueDelay);
        }
        DisableText();
    }

    /// <summary>
    /// If you interact with an object that gives an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InteractiveObject interactiveObject, bool isRemoved, InventoryObject inventoryObject, string dialogueText)
    {
        AddObject(inventoryObject);
        EnableText(dialogueText);
        yield return new WaitForSeconds(dialogueDelay);
        if (isRemoved)
            interactiveObject.gameObject.SetActive(false);
        DisableText();
    }

    /// <summary>
    /// If you interact with a "locked" object that does NOT give an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InteractiveObject interactiveObject, bool isRemoved, string successText, string failText, int ObjectID)
    {
        if (hasItem(ObjectID))
        {
            EnableText(successText);
            yield return new WaitForSeconds(dialogueDelay);
            if(isRemoved) 
                interactiveObject.gameObject.SetActive(false);
        }
        else
        {
            EnableText(failText);
            yield return new WaitForSeconds(dialogueDelay);
        }
        DisableText();
    }

    /// <summary>
    /// If you interact with an object that does not give an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InteractiveObject interactiveObject, bool isRemoved, string dialogueText)
    {
        EnableText(dialogueText);
        yield return new WaitForSeconds(dialogueDelay);
        if (isRemoved)
            interactiveObject.gameObject.SetActive(false);
        DisableText();
    }
    #endregion

    /// <summary>
    /// Adds an InventoryObject to the Inventory
    /// </summary>
    private void AddObject(InventoryObject Object)
    {
        inventory.Add(Object);
    }

    /// <summary>
    /// Removes an InventoryObject in the Inventory if it is there.
    /// </summary>
    /// <param name="ObjectID">The Key ID of the object to be removed</param>
    private void RemoveObject(int ObjectID)
    {
        foreach(InventoryObject Object in inventory)
        {
            if(Object.getKeyID() == ObjectID)
            {
                inventory.Remove(Object);
            }
        }
    }

    private void EnableText(string text)
    {
        playerMovement.toggleMovement(false);
        playerInteraction.toggleCanInteract(false);
        UI.enabled = true;
        dialogueText.text = text;
    }

    private void DisableText()
    {
        playerMovement.toggleMovement(true);
        playerInteraction.toggleCanInteract(true);
        UI.enabled = false;
        dialogueText.text = null;
    }

    public bool hasItem(int ID)
    {
        foreach(InventoryObject Object in inventory)
        {
            if (Object.getKeyID() == ID)
            {
                return true;
            }
        }
        return false;
    }
}
