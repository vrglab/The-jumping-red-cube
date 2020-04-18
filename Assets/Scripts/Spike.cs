using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spike : MonoBehaviour
{
    private Player p;

    void Start()
    {
        p = GameObject.Find("Player").GetComponent<Player>();
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            if(p.isDead == false)
            {
                p.Death();
            }
           
        }
    }
}
