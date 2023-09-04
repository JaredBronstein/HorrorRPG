using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private double movementSpeed;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        if (rigidbody == null)
            rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            rigidbody.velocity = new Vector2 ((float)movementSpeed * Input.GetAxisRaw("Horizontal"), 0);
        }
        else if (Input.GetButton("Vertical"))
        {
            rigidbody.velocity = new Vector2(0, (float)movementSpeed * Input.GetAxisRaw("Vertical"));
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
