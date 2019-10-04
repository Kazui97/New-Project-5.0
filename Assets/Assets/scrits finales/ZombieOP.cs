using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.ally;




namespace Npc
{
    namespace enemy
    {
        public class ZombieOP : NpcEstado
        {           
            public CosasZombie datosZombi;                                // ----------- struc de gustos y color ------------- \\
            public GameObject textoz;
            public Image Hpenemy;
            public float vidaZmax = 100;
            public float vidaactualz;
            public float daño = -2;
            void Awake()
            {
                datosZombi.colorEs = (CosasZombie.ColorZombie)Random.Range(0, 3);
                int dargusto = Random.Range(0, 5);
                datosZombi.sabroso = (CosasZombie.Gustos)dargusto;
                datosZombi.edadzombi = Random.Range(15, 101);
                textoz = GameObject.Find("Main Camera");
                
            }

            void HpZ()               // funcion que se utliza para la vida del zombie \\
            {
                vidaactualz -= 15;
                if (vidaactualz > vidaZmax)
                {
                    vidaactualz = vidaZmax;
                }
                else if (vidaactualz < 0)
                {
                    vidaactualz = 0;
                    Debug.Log("zombi melto");
                    Destroy(this.gameObject); /// SIRVE


                }
                Hpzombi();
            }

            void Hpzombi()                       // actualiza la imagen de que contiene el HP del Zombie \\
            {
                Hpenemy.fillAmount = ((1 / vidaZmax) * vidaactualz);
            }
            public void OnCollisionEnter(Collision collision)    // comfirma la colicion y y ejecuta la funcion HpZ \\
            {
                if (collision.transform.name == "player")
                {
                    HpZ();
                    Debug.Log(vidaactualz);
                }
            }
            public void Cam ()                                      // color de los zombies-ciudadanos cuando se transforman \\
            {
                int cambiocolor = Random.Range(1,3);
                 switch (cambiocolor)
                 {
                    case 1:
                        gameObject.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case 2:
                        gameObject.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case 3:
                        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                 }
            }
            Vector3 direction;
            void OnDrawGizmos()             // sirve para ver la direccion en la que el zombie  se mueve \\
            {
                Gizmos.DrawLine(transform.position, transform.position + direction);  
            }

            public GameObject JugadorObjeto;
           
            void Start()
            {
                vidaactualz = vidaZmax;
                StartCoroutine("Cambioestado");

                JugadorObjeto = FindObjectOfType<Hero>().gameObject;  // indica que el player ya es identificado por el zombi\\


            }         
            
            

            void Update()
            {       
                float distanciaMin = 5;
                GameObject ciudadanoMasCercano = null;
                                                                    //significa que todos los zombies buscaran presas :v \\
                foreach (var ciudadano in FindObjectsOfType<CiudadanoOp>())
                {
                    float tempDist = Vector3.Distance(this.transform.position, ciudadano.transform.position);

                    if (tempDist < distanciaMin)
                    {
                        distanciaMin = tempDist;
                        ciudadanoMasCercano = ciudadano.gameObject;
                    }
                }

                Vector3 mivector = JugadorObjeto.transform.position - transform.position;
                float distanciajugador = mivector.magnitude;

                if (ciudadanoMasCercano != null) //sigbnifica que hay un ciudadano cerca 
                {
                    direction = Vector3.Normalize(ciudadanoMasCercano.transform.position - transform.position);
                    transform.position += direction * 2.5f / datosZombi.edadzombi;
                }
                else if (distanciajugador <= 3.0f)          // significa que los zombies trataran de asesinar al heroe \\
                {
                    
                    direction = Vector3.Normalize(JugadorObjeto.transform.position - transform.position);
                    transform.position += direction * 1.1f;
                    FindObjectsOfType<ZombieOP>();

                }
                else // no hay un ciudadano cerca... el zombie entrara a sus estados normales hasta que encuentre otra presa
                {
                    Statemovi();
                    
                }

            }

        }
        
    }
   
    public struct CosasZombie                   // las estructuras se estan utilizando para almacenar los enum para poder acceder desde otro scrip\\
    {
        
        public enum Gustos
        {
            Brazos,
            Piernas,
            Huesitos,
            Ojito,
            corazoncito
        };
        public Gustos sabroso;       

        public enum ColorZombie
        {
            magenta,
            green,
            cyan
        };
        
        public ColorZombie colorEs;

        public int edadzombi;
    }
}


   






