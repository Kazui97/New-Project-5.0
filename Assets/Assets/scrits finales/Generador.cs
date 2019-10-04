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
    CosasZombie datoszombi;
    CosasCiudadanos datoCiudadanos;    
    readonly int minimo = 5;
    const int maximo = 30;
    int cantbody;
    int canvamp;
    public Text enemy;
    public Text ally;
    public Text vampi;
    public Text Ztext;
    public Text ctext;

    void Start()
    {                                 // generador de NPC
        cantbody = Random.Range(minimo, maximo);
        
                                            //------------------------ creacion zombis y aldeanos -----------------\\
        for (int i = 0; i < cantbody; i++)
        {
            if (Random.Range(0,2)==0)
            {           
                                                                                // generador de zombis
                ZombieMesh = Instantiate<GameObject>(ZombieMesh);
                Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
               ZombieMesh.transform.position = pos;     
               ZombieMesh.name = "Zombi";
            }
            else if (Random.Range(0,2)== 1)                                             // generador de ciudadanos \\
            {
                Gente = Instantiate<GameObject>(Gente);
                Vector3 po = new Vector3(Random.Range(-30, 10), 0, Random.Range(-30, 10));
                Gente.transform.position = po;
                Gente.name = "Gente";
            }
            else                                                                                  // generador de vampiro \\
            {

                VampiroMesh = Instantiate<GameObject>(VampiroMesh);
                Vector3 poss = new Vector3(Random.Range(-20,10),0, Random.Range(-20,10));
                VampiroMesh.transform.position = poss;   
                VampiroMesh.name ="vampi";
                
            }
        }
        
       int numzombie = 0;
       int numaldeanos = 0;
       int numvampiro = 0; 
       // texto canvas \\                                                   // busca todo los objetos que se hallan creado que tengan el mismo scrits y los agrega a un contador para depues utilizar el contador y envialor a un texto del canvas\\
        foreach (ZombieOP enemy in Transform.FindObjectsOfType<ZombieOP>())
        {
           numzombie++;
        }

        foreach (CiudadanoOp ally in Transform.FindObjectsOfType<CiudadanoOp>())
        {
            numaldeanos++;
        }
        foreach (VampiroOP enemy in Transform.FindObjectsOfType<VampiroOP>())
        {
            numvampiro++;
        }       
        ally.text="aldeanos: "+numaldeanos;
        enemy.text="zombies: "+numzombie;
        vampi.text = "vampiros:" + numvampiro;
    }

}
