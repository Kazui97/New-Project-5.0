using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.enemy;

public class Sword : MonoBehaviour
{
    public GameObject espada;
    public int dañoespada = 15;

    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.enabled = false;
    }
     public void  OnCollisionEnter(Collision colespada)
     {
         if (colespada.transform.name == "Zombi")
         {     
            //vidaactualz -= dañoespada;
         }
       
     }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.enabled = true;                      
        }
        else
        {
            anim.enabled = false;
        }
    }
}
