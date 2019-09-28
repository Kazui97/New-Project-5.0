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

    //public float vidamax = 100f;
    //float V_actual;

    //public Image barravida;
    //void Start()
    //{
    //    V_actual = vidamax;
    //    barravida.fillAmount = vidamax / V_actual;
    //}
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.transform.name == "Zombi")
    //    {
    //        V_actual -= 1f;
    //        barravida.fillAmount = V_actual / vidamax;
    //        Debug.Log("funciona");
    //    }
    //    if (V_actual <= 0)
    //    {
    //        Debug.Log("esay :,v");
    //    }
    //}


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)          // colision de zombi y aldeanos 
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
    }
}
