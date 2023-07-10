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
    }

    //Animation Event
    void ToggleOff(string Name)
    {
        animator.SetBool("Slide", false);
    }

    private void OnAnimatorMove() 
    {
        rb.MovePosition(rb.position + Vector3.forward * animator.deltaPosition.magnitude);    
    }
}
