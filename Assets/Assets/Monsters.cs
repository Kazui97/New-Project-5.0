using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    
    class Monster
    {
        public int hp;
        public GameObject prueba;

        public Monster()
        {
            hp = 50;
            prueba = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Debug.Log("un cubo nuevo");
        }
        public virtual int takedagame(int damage)
        {
            return hp - damage;
        }
    }

    class zombie : Monster
    {
        public override int takedagame(int damage)
        {
           return hp - (damage);
        }
    }
    class vampire : Monster
    {
        public override int takedagame(int damage)
        {
            return hp -(damage/2);
        }
    }











    void Start()
    {
        zombie Z = new zombie();
        vampire V = new vampire();
        Debug.Log (Z.takedagame(5));
        Debug.Log (V.takedagame(5));
    }

    
    void Update()
    {
        
    }
}
