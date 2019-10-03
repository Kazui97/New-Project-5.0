using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.ally;
using Npc.enemy;
using Npc;



 public class Hero : MonoBehaviour
{
    CosasZombie datosZombi;
    CosasCiudadanos datosciudadanos;
    //public GameObject espada;
    public GameObject botiquin;
    public Image HpHero;
    public float HpMax = 100;
    public float HpActual;
    public float cura;
    
    

    void Start()
    {
        cura = Random.Range(5,50);
        HpActual = HpMax;
        botiquin = Instantiate<GameObject>(botiquin);
        Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        botiquin.transform.position = pos;
        botiquin.name = "curas";
       // espada = Instantiate<GameObject>(espada);
    }
    public void AddhP()
    {
        HpActual -= 10f;
        if (HpActual > HpMax)
        {
            HpActual = HpMax;
        }
        else if (HpActual < 0)
        {
            HpActual = 0;
            
        }
        Hpstate();

    }
    
     void Hpstate()
        {
            HpHero.fillAmount = ((1/ HpMax) * HpActual);         
        }

    public void OnCollisionEnter(Collision col)
    {
        /*if ( col.transform.name == "Zombi")
        {           
            AddhP();

           
        }*/
         if (col.transform.name == "curas")
         {
                HpActual += cura;
                Hpstate();
                if (HpActual > HpMax)
                {
                    HpActual = HpMax;
                }
         }
        
    }

    

    void Update()
    {
    }

   /* private void OnCollisionEnter(Collision collision)          // colision de zombi y aldeanos 
    {
        if (collision.transform.name == "Zombi")
        {
            //datosZombi = collision.gameObject.GetComponent<ZombieOP>().datosZombi;
            //Debug.Log("  waaarrr " + " quiero comer " + datosZombi.sabroso);
        }


        if (collision.transform.name == "Gente")
        {
            datosciudadanos = collision.gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;
            Debug.Log("Hola soy " + datosciudadanos.genteNombres + " y tengo " + datosciudadanos.edadgente);
        }
    }*/
}
