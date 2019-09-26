using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
     
    
    
        public int hp;
        public GameObject prueba;

        public Monsters()
        {
            hp = 50;
            //prueba = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Debug.Log("un cubo nuevo");
        }
        public virtual int takedagame(int damage)
        {
            return hp - damage;
        }
    

   /*  class zombie : Monsters
    {
        public override int takedagame(int damage)
        {
        return hp - (damage);
        }
    }*/
    class vampire : Monsters
    {
        public override int takedagame(int damage)
        {
            return hp -(damage/2);
        }
    }



    int cambimov;
        void Start()
    {
           // Zombie Z = new zombie();
            vampire V = new vampire();
          //  Debug.Log (Z.takedagame(5));
            Debug.Log (V.takedagame(5));




        condicion = (Estados)0;

    }

    public void Statemovi()
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
    IEnumerator Cambioestado()
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
       

