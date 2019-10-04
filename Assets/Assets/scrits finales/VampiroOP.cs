using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;
using UnityEngine.UI;

public class VampiroOP : Npc.NpcEstado
{
    public GameObject jugadorObjeto;
    public int vidavampiro;                                 //variable que indica la vida actual del vampiro
    public int vidamax = 150;                           // variable que indica la vida maxima de vampiro
    public Image hpenemyV;                              // creamos esta imagen para poder agregar la imagen de vida que se habia creado en la jeranquia
    Vector3 direcc;
     void OnDrawGizmos()   // el gizmo muestra con una flecha asi donde el vampiro de dirige 
     {
         Gizmos.DrawLine(transform.position, transform.position + direcc); 
     }




    void Start()
    {
        vidavampiro = vidamax;
        StartCoroutine("Cambioestado");
        
        jugadorObjeto = FindObjectOfType<Hero>().gameObject;

        int color = Random.Range(0,2);
        switch (color)
        {
            case 0:
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            break;
            case 1:
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            break;
            case 2:
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            break;
            
        }
    }

    void HpV()               // funcion que se utliza para la vida que funciona como limitador  \\
    {
        vidavampiro -= 30;
        if (vidavampiro > vidamax)
        {
            vidavampiro = vidamax;
        }
        else if (vidavampiro < 0)
        {
            vidavampiro = 0;
            Debug.Log("zombi melto");
            Destroy(this.gameObject); /// SIRVE


        }
        Hpvampiro();
    }

    void Hpvampiro()                       // actualiza la imagen de que contiene el HP del Zombie \\
    {
        hpenemyV.fillAmount = ((1 / vidamax) * vidavampiro);
    }
    public void OnCollisionEnter(Collision collision)    // comfirma la colicion y y ejecuta la funcion HpZ \\
    {
        if (collision.transform.name == "player")
        {
            HpV();
        }
    }

    void Update()
    {
        float distaciamin=5;
        GameObject ciudadanocerca = null;

        foreach (var ciudadano in FindObjectsOfType<CiudadanoOp>())
        {
            float tempdist = Vector3.Distance(this.transform.position, ciudadano.transform.position);
            if (tempdist < distaciamin )
            {
                 distaciamin = tempdist;
                 ciudadanocerca = ciudadano.gameObject;
            }
            
        }
        Vector3 mvector = jugadorObjeto.transform.position - transform.position;
        float distanciajugador = mvector.magnitude;
        if (ciudadanocerca != null)
        {
            direcc = Vector3.Normalize(ciudadanocerca.transform.position - transform.position);
            transform.position += direcc * 0.2f;
        }
        else if (distanciajugador <= 3.0f )
        {
            direcc = Vector3.Normalize(jugadorObjeto.transform.position - transform.position);
            transform.position += direcc * 0.2f;
        }
        else 
        {
            Statemovi();


        }
    }
}
