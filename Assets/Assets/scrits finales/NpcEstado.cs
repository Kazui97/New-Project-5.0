﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Npc
{
    public class NpcEstado : MonoBehaviour
    {        
        int cambimov;
         void Start()
        {
            condicion = (Estados)0;                     // creacion de la corutina 
        }

        public void Statemovi()             //funcion que activa los moviminto de los Npc
        {
            switch(condicion)
            {
                case Estados.Idle:
                    transform.position += new Vector3(0, 0f, 0);
                    break;
                case Estados.Moving:
                    if (cambimov == 0)
                    {
                        transform.position += new Vector3(0, 0, 0.03f);
                    }
                    else if (cambimov == 1)
                    {
                        transform.position -= new Vector3(0, 0, 0.03f);
                    }
                    else if (cambimov == 2)
                    {
                        transform.position -= new Vector3(0.03f, 0, 0);
                    }
                    else if (cambimov == 3)
                    {
                        transform.position += new Vector3(0.03f, 0, 0);
                    }
                    break;

                case Estados.Rotating:
                    transform.eulerAngles += new Vector3(0, 0.5f, 0);

                    break;

                default:
                    break;
            }
        }
        IEnumerator Cambioestado()          // corutina que actualiza cada 3sg el cambio de estado de los npc \\
        {
            while (true)
            {
                condicion = (Estados)Random.Range(0, 3);
                yield return new WaitForSeconds(3);

                if (condicion == (Estados)0)
                {
                    condicion = (Estados)1;
                    cambimov = Random.Range(0, 3);
                }
                else if (condicion == (Estados)1)
                {
                    condicion = (Estados)2;
                }

            }


        }
        public enum Estados
        {
            Idle,
            Moving,
            Rotating
        };
        public Estados condicion;
       
    }
}

