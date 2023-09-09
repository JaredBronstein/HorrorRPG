using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private double movementSpeed;

    private bool canMove = true;
    private BoxCollider2D interactionTrigger;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        foreach (BoxCollider2D trigger in this.gameObject.GetComponents<BoxCollider2D>())
        {
            if (trigger.isTrigger == true)
            {
                interactionTrigger = trigger;
            }
        }

        if (rigidbody == null)
            rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetButton("Horizontal"))
            {
                triggerAdjust(true);
                rigidbody.velocity = new Vector2((float)movementSpeed * Input.GetAxisRaw("Horizontal"), 0);
            }
            else if (Input.GetButton("Vertical"))
            {
                triggerAdjust(false);
                rigidbody.velocity = new Vector2(0, (float)movementSpeed * Input.GetAxisRaw("Vertical"));
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
            }
        }
    }
    /// <summary>
    /// Adjusts the position of the trigger collider on the Player to account for the way the player is moving.
    /// </summary>
    /// <param name="isHorizontal">Simple bool to check the two outcomes.</param>
    private void triggerAdjust(bool isHorizontal)
    {
        if(isHorizontal)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                interactionTrigger.offset = new Vector2((float)0.85, 0);
                interactionTrigger.size = new Vector2(0.7f, 0.4f);
            }
            else
            {
                interactionTrigger.offset = new Vector2(-0.85f, 0);
                interactionTrigger.size = new Vector2(0.7f, 0.4f);
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                interactionTrigger.offset = new Vector2(0, 0.85f);
                interactionTrigger.size = new Vector2(0.4f, 0.7f);
            }
            else
            {
                interactionTrigger.offset = new Vector2(0, (float)-0.85);
                interactionTrigger.size = new Vector2(0.4f, (float)0.7);
            }
        }
    }

    public void toggleMovement(bool CanMove)
    {
        canMove = CanMove;
    }
}
