using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    
    Animator anim;
    public bool moveRight;
    public float speed;
    private bool is_patrol;
    private Vector3 rotation_sprite;
    private bool attack;
    private bool hitted;
    private int numbersOfHitted;
    private bool added;
    void Start()
    {
        added = false;
        numbersOfHitted = 0;
        hitted = false;
        is_patrol = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (is_patrol == true)
        {
            
           
            if (moveRight==true )
            {
                transform.Translate(1*speed * Time.deltaTime, 0, 0);
                rotation_sprite = new Vector3(1, 1, 1);
                transform.localScale = rotation_sprite;
            }
           if(moveRight==false)
            {
                transform.Translate(-1*speed * Time.deltaTime, 0, 0);
                rotation_sprite = new Vector3(-1, 1, 1);
                transform.localScale = rotation_sprite;
            }
        }
        if(attack==false)
        {
            anim.Play("running");
            hitted = false;
            added = false;
            is_patrol = true;
        }
        if(attack==true)
        {
            anim.Play("attack");
            hitted = true;
            is_patrol = false;
        }
        if(hitted==true&&added==false)
        {

          
            added=true;
            increase_hitted_times();
        }
      
    }
    private void increase_hitted_times()
    {
      
            numbersOfHitted++;
       
        Debug.Log(numbersOfHitted);
    }
    public void setting(bool is_attack)
    {
       // attacking = is_attack;
       attack = is_attack;
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==9)
        {
            if (other.gameObject.CompareTag("triggerForEnemy"))
            {
                if (moveRight == true)
                {
                    moveRight = false;
                }
                else
                {
                    moveRight = true;
                }
            }
        }

    }

}
