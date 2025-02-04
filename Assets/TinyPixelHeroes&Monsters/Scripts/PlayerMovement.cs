using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer sprite;
    
    private Vector2 move;
    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        ActionChar();           
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            MoveChar();
        }       
    }

    void CanMove()
    {
        canMove = true;
    }
    void TrueColor()
    {
        sprite.color = Color.white;
    }

    private void ActionChar()
    {
        //Attack
        if (Input.GetKeyDown(KeyCode.E))
        {
            canMove = false;
            animator.SetTrigger("Attack");
            Invoke("CanMove", 1);
        }
        //Power
        if (Input.GetKeyDown(KeyCode.R))
        {
            canMove = false;
            animator.SetTrigger("Power");
            Invoke("CanMove", 1);
        }
        //Death
        if (Input.GetKeyDown(KeyCode.Y))
        {
            canMove = false;
            animator.SetTrigger("Death");
            Invoke("CanMove", (float)1.6);
        }
        //Hurt
        if (Input.GetKeyDown(KeyCode.T))
        {
            sprite.color = Color.red;
            Invoke("TrueColor", (float)0.2);
        }
    }
       
    private void MoveChar()
    {
        rb2D.MovePosition(rb2D.position + move * moveSpeed * Time.fixedDeltaTime);
       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }     
    }
}

