using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : Npc.enemy.ZombieOP
{
    public GameObject espada;
    public int dañoespada = 15;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.enabled = false;
    }
     public new void  OnCollisionEnter(Collision colespada)
     {
         if (colespada.transform.name == "Zombi")
        {
            vidaactualz -= dañoespada;
        }
     }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.enabled = true;
            Debug.Log("pega*");
            
        }
        else
        {
            anim.enabled = false;
        }
    }
}
