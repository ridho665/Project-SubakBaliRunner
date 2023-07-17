using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private int Next_X_POS;
    private bool Left, Right;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
                animator.SetBool("Right", true);
            else
                Right = true;
            if (rb.position.x >= -3 && rb.position.x < -1)
            {
                Next_X_POS = 0;
            }
            else if (rb.position.x >= -1 && rb.position.x < 1)
            {
                Next_X_POS = 2;
            }
        }  
        else if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {   
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
                animator.SetBool("Left", true);
            else
                Left = true;
            if (rb.position.x >= 1 && rb.position.x < 3)
            {
                Next_X_POS = 0;
            }
            else if (rb.position.x >= -1 && rb.position.x < 1)
            {
                Next_X_POS = -2;
            }
        }    
    }

    //Animation Event
    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
        isJumpDown = false;
    }

    private bool isJumpDown = false;
    void JumpDown()
    {
        isJumpDown = true;
    }

    private void OnAnimatorMove() 
    {
        if (animator.GetBool("Jump"))
        {
            if (isJumpDown)
                rb.MovePosition(rb.position + new Vector3(0, 0, 2) * animator.deltaPosition.magnitude);
            else
                rb.MovePosition(rb.position + new Vector3(0, 1.5f, 2) * animator.deltaPosition.magnitude);    
        }
        else if (animator.GetBool("Right"))
        {
            if (rb.position.x < Next_X_POS)
                rb.MovePosition(rb.position + new Vector3(1, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Right", false);
        }
        else if (animator.GetBool("Left"))
        {
            if (rb.position.x > Next_X_POS)
                rb.MovePosition(rb.position + new Vector3(-1, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Left", false);
        }
        else
        {
            rb.MovePosition(rb.position + Vector3.forward * animator.deltaPosition.magnitude);
        }

        if (Left)
        {
            if (rb.position.x > Next_X_POS)
                rb.MovePosition(rb.position + new Vector3(-1, 0, 0) * animator.deltaPosition.magnitude);
            else
                Left = false; 
        }

        else if (Right)
        {
            if (rb.position.x < Next_X_POS)
                rb.MovePosition(rb.position + new Vector3(1, 0, 0) * animator.deltaPosition.magnitude);
            else
                Right = false;
        }
            
    }
}
