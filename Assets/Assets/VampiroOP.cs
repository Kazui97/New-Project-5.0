using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;

public class VampiroOP : Monsters
{
    public GameObject jugadorObjeto;
    

    Vector3 direcc;
     void OnDrawGizmos()
     {
         Gizmos.DrawLine(transform.position, transform.position + direcc);
     }




    void Start()
    {
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
            transform.position += direcc * 0.5f;
        }
        else if (distanciajugador <= 3.0f )
        {
            direcc = Vector3.Normalize(jugadorObjeto.transform.position - transform.position);
            transform.position += direcc * 0.1f;
        }
        else 
        {
            Statemovi();
        }
    }
}
