using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private bool can_move;
    private float speed;
    public bool is_up;
    public GameObject trigger;

    void Start()
    {
        
        can_move = false;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sizeVec = trigger.GetComponent<Collider>().bounds.size;

        if (can_move == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                is_up = !is_up; ;
            }
        }
            if (is_up == true)
            {
                
               // Transform transform1 = trigger.transform;
                if (transform.position.y<=( trigger.transform.position.y+sizeVec.y/2)-0.1f)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            if (is_up == false)
            {
                
                if (transform.position.y >=trigger.transform.position.y-sizeVec.y/2)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
            }
        
     /*   if(can_move==false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                is_up = !is_up; ;
            }

            if (is_up == true)
            {
                if (transform.position.y <= 1.5f)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }

            }
            if (is_up == false)
            {
                if (transform.position.y >= 0.2f)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
            }
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("player"))
        {
            can_move = true;
           
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("player")) 
        {
            can_move = false;
        }

    }
}

