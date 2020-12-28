using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Charcontroller : MonoBehaviour
{
    public float speed;
    public float jump_speed;
    private Vector3 rotation_sprite;
    bool on_ground;
    private Rigidbody rb;
    private Animator animator;
    private bool is_moving;
    private bool is_jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // on_ground = false;
        is_moving = false;
        is_jumping = false;
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 translation = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);
       //translation *= Time.deltaTime;
        //  transform.Translate(translation, 0, 0);

         
        rb.MovePosition(transform.position + translation*speed*Time.deltaTime);

           if (Input.GetKey(KeyCode.A))
            {
                is_moving = true;
                rotation_sprite = new Vector3(-1, 1, 1);
                transform.localScale = rotation_sprite;
            }
            if (Input.GetKey(KeyCode.D))
            {
                is_moving = true;
                rotation_sprite = new Vector3(1, 1, 1);
                transform.localScale = rotation_sprite;
            }



        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            is_moving = false;
        }
        if (is_moving == false&&is_jumping==false)
        {
            animator.Play("Idle");
        }
        if(is_moving==true&&is_jumping==false)
        {
            animator.Play("running");
        }
        

        if(is_jumping==true)
        {
            animator.Play("Jump");
        }
        if (on_ground==true)
          {
              
               if(Input.GetKeyDown(KeyCode.Space))
               {

                is_jumping = true;
                rb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
               }
               if(Input.GetKeyUp(KeyCode.Space))
               {
                is_jumping = true;
                on_ground = false;
               }
          }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag=="ground")
        {
            on_ground = true;
            is_jumping = false;
        }
       
    }

}

