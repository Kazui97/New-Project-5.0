using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public float vidamax = 100;
    public float V_actual;

    public Image barravida;

    private void Start()
    {
        V_actual = vidamax;
    }
    [ContextMenu("add")]
    public void AddHealth(float daño)
    {
        //V_actual += daño;
        if (V_actual > vidamax)
        {
            V_actual = vidamax;
        }
        else if (V_actual < 0)
        {
            V_actual = 0;
            
        }
        vidactual();

        void vidactual()
        {
            barravida.fillAmount = (1 / vidamax) * V_actual;
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Zombi")
        {
            //AddHealth() = collision.gameObject.GetComponent<Npc.enemy.ZombieOP>().daño;
            V_actual += collision.gameObject.GetComponent<Npc.enemy.ZombieOP>().daño;
           
        }
         
    }
}


























    //void Start()
    //{
    //    V_actual = vidamax;
    //    barravida.fillAmount = V_actual / vidamax;
    //}
    //private void OnCollisionEnter(Collision col)
    //{
    //   if(col.transform.name == "vampi")
    //    {
    //        V_actual -= col.gameObject.GetComponent<VampiroOP>().hp;
    //        barravida.fillAmount = V_actual / vidamax;
    //        Debug.Log("funciona");
    //    }
    //   if (V_actual <= 0)
    //    {
    //        Debug.Log("esay :,v");
    //    }
    //}

    //void Update()
    //{
    //    //update_Hp();
    //}

    //void update_Hp()
    //{
    //    float z = (float)V_actual / (float)vidamax;
    //    Vector3 ScaleBar = new Vector3(1, 1, z);
    //    Hp_bar.transform.localScale = ScaleBar;

    //}

