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
    public Image HpHero;
    public float HpMax = 100;
    public float HpActual;
    void start()
    {
        HpActual = HpMax;
      
    }

    public void OnCollisionEnter(Collision col)
    {
        if ( col.transform.name == "Zombi")
        {
           
            HpActual += -10f;
            if (HpActual > HpMax)
            {
                HpActual = HpMax;
            }
            else if (HpActual < 0)
            {
                HpActual = 0;
            }
        }
        Hpstate();
        
    }

    void Hpstate()
    {
        HpHero.fillAmount = ((1/ HpActual) * HpMax);
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
