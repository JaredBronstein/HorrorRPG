using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private BoxCollider2D interactionTrigger;

    private InteractiveObject currentTarget;

    private void Awake()
    {
        foreach(BoxCollider2D trigger in this.gameObject.GetComponents<BoxCollider2D>())
        {
            if(trigger.isTrigger == true)
            {
                interactionTrigger = trigger;
            }
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && currentTarget != null)
        {
            Debug.Log("Interacting with: " + currentTarget.gameObject.name);
            currentTarget.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractiveObject>() != null)
        {
            Debug.Log("Assigning new target: " +  collision.gameObject.name);
            currentTarget = collision.gameObject.GetComponent<InteractiveObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Removing current target");
        currentTarget = null;
    }
}
