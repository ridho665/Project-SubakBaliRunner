using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
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
    }

    //Animation Event
    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
    }

    private void OnAnimatorMove() 
    {
        if (animator.GetBool("Jump"))
        {
            rb.MovePosition(rb.position + new Vector3(0,0.7f,1) * animator.deltaPosition.magnitude);
        }
        else
        rb.MovePosition(rb.position + Vector3.forward * animator.deltaPosition.magnitude);    
    }
}
