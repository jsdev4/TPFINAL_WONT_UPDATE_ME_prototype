using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToPlayer : MonoBehaviour
{
    public GameObject enemy;
    private bool attack;

    void Start()
    {
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack==true)
        {

            enemy.GetComponent<EnemyScript>().setting(true);
        }
        else
        {
            enemy.GetComponent<EnemyScript>().setting(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {

                attack = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {

            attack = false;

        }
    }
}
