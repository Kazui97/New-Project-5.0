using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;
using Npc.ally;
using Npc.enemy;
using Npc;



public class Generador : MonoBehaviour
{
    public GameObject ZombieMesh;
    public GameObject VampiroMesh;
    public GameObject Gente;
    public GameObject Hero;
    CosasZombie datoszombi;
    CosasCiudadanos datoCiudadanos;    
    readonly int minimo = 5;
    const int maximo = 30;
    int cantbody;
    int canvamp;
    public Text enemy;
    public Text ally;
    public Text Ztext;
    public Text ctext;



   /*  System.Random rn = new System.Random();
    System.Random vamp = new System.Random();*/
    /*public Generador()
    {
        minimo = rn.Next(5, 15);    //rango de creación
        minimo = vamp.Next(5,15);
    }*/

    void Start()
    {                                 // generador de NPC
        cantbody = Random.Range(minimo, maximo);
        
                                            //------------------------ creacion zombis y aldeanos -----------------\\
        for (int i = 0; i < cantbody; i++)
        {
            if (Random.Range(0,2)==0)
            {           
                // generador de zombis
                ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                ZombieMesh.AddComponent<ZombieOP>();
                
                datoszombi = ZombieMesh.GetComponent<ZombieOP>().datosZombi;
                
                switch (datoszombi.colorEs)
                {
                    case CosasZombie.ColorZombie.magenta:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case CosasZombie.ColorZombie.green:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case CosasZombie.ColorZombie.cyan:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }
                

                Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

               
                ZombieMesh.transform.position = pos;
                
               ZombieMesh.AddComponent<Rigidbody>();
                
               ZombieMesh.name = "Zombi";
            }
            else if (Random.Range(0,2)== 1)// generador de ciudadanos \\
            {
                Gente = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gente.AddComponent<CiudadanoOp>();
                Vector3 po = new Vector3(Random.Range(-20, 10), 0, Random.Range(10, 10));
                Gente.transform.position = po;
                Gente.AddComponent<Rigidbody>();
                Gente.name = "Gente";
            }
            else
            {
                 
                VampiroMesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                VampiroMesh.AddComponent<VampiroOP>();
                Vector3 poss = new Vector3(Random.Range(-20,20),0, Random.Range(-20,20));
                VampiroMesh.transform.position = poss;
                VampiroMesh.AddComponent<Rigidbody>();
                VampiroMesh.name ="vampi";
                
            }
        }
 
        // generador hero \\
        Hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Hero.AddComponent<MovimientoTeclado>();
        Hero.AddComponent<Hero>();
        Hero.AddComponent<Camera>();
        Hero.AddComponent<Rigidbody>();
        Hero.name = "Hero";

            
       int numzombie = 0;
       int numaldeanos = 0;

       // texto canvas \\
        foreach (ZombieOP enemy in Transform.FindObjectsOfType<ZombieOP>())
        {
           numzombie++;
        }

        foreach (CiudadanoOp ally in Transform.FindObjectsOfType<CiudadanoOp>())
        {
            numaldeanos++;
        }
        Debug.Log("contador"+numzombie);
        ally.text="aldeanos: "+numaldeanos;
        enemy.text="zombies: "+numzombie;
      
    }

}
