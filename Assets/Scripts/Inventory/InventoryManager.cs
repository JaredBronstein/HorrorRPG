using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text dialogueText;

    private Canvas UI;
    private PlayerMovement playerMovement;
    private List<InventoryObject> inventory = new List<InventoryObject>();

    private void Awake()
    {
        UI = this.GetComponent<Canvas>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        UI.enabled = false;
    }

    #region HandlingInteractiveObjects
    /// <summary>
    /// If you interact with a "locked" object that gives an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InventoryObject inventoryObject, string successText, string failText, int ObjectID)
    {
        if (hasItem(ObjectID))
        {
            AddObject(inventoryObject);
            EnableText(successText);
        }
        else
        {
            EnableText(failText);
        }
        yield return new WaitForSeconds(2.0f);
        DisableText();
    }

    /// <summary>
    /// If you interact with an object that gives an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(InventoryObject inventoryObject, string dialogueText)
    {
        AddObject(inventoryObject);
        EnableText(dialogueText);
        yield return new WaitForSeconds(2.0f);
        DisableText();
    }

    /// <summary>
    /// If you interact with a "locked" object that does NOT give an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(string successText, string failText, int ObjectID)
    {
        if (hasItem(ObjectID))
        {
            EnableText(successText);
        }
        else
        {
            EnableText(failText);
        }
        yield return new WaitForSeconds(2.0f);
        DisableText();
    }

    /// <summary>
    /// If you interact with ab object that does not give an inventory object
    /// </summary>
    public IEnumerator HandleInteractiveObject(string dialogueText)
    {
        EnableText(dialogueText);
        yield return new WaitForSeconds(2.0f);
        DisableText();
    }
    #endregion

    private void AddObject(InventoryObject Object)
    {
        inventory.Add(Object);
    }

    private void EnableText(string text)
    {
        UI.enabled = true;
        playerMovement.toggleMovement(false);
        dialogueText.text = text;
    }

    private void DisableText()
    {
        UI.enabled = false;
        playerMovement.toggleMovement(true);
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
