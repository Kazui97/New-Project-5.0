using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.enemy;




namespace Npc
{
    namespace ally
    {
        public class CiudadanoOp : NpcEstado
        {
            public CosasCiudadanos datoCiudadanos;
            public GameObject JugadorObjeto;
            public GameObject textc;
            CosasZombie zombicosas;
            

            void Awake()
            {
                int darnombre = Random.Range(0, 20);
                datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)darnombre;
                datoCiudadanos.edadgente = Random.Range(15, 101);
                textc = GameObject.Find("Main Camera");
            }

            void Start()
            {
                float cual = 2.5f;
                int camb = (int) cual;
               
                StartCoroutine("Cambioestado");
                 JugadorObjeto = FindObjectOfType<Hero>().gameObject;           // aqui se identifica el player para que el ciudadano pueda darmel mensaje\\
            }
            Vector3 direc;
            void OnDrawGizmos()     // sirve para ver la direccion en la que el ciudadano hulle o se mueve \\
            {
                Gizmos.DrawLine(transform.position, transform.position - direc);
            }

            
            public void OnCollisionEnter(Collision collision)   // la colision indica si el aldeano choco con un zombi o un vampiro y si es cualquera de ellos el adquiere losestado del que lo alla colisionado \\
            {
                if (collision.transform.name == "Zombi")
                {                   
                    transform.name = "Zombi"; 
                    ZombieOP cambioedad = gameObject.AddComponent<ZombieOP>();
                    gameObject.GetComponent<ZombieOP>().Cam();  
                    cambioedad.datosZombi = (CosasZombie) gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;
                    Destroy(this.gameObject.GetComponent<CiudadanoOp>());    
                }
                else if (collision.transform.name == "vampi")
                {
                    transform.name = "vampi";
                    gameObject.AddComponent<VampiroOP>();
                    Destroy(this.gameObject.GetComponent<CiudadanoOp>());
                }
            }


            
            void Update()
            {
                float distmin = 5;                          ///-------------corre de los zombie------------\\\
                GameObject zombimascerca = null;
                GameObject vampimascerca = null;

                foreach (var item in FindObjectsOfType<ZombieOP>()) // identifica todos los objetos que tengan el componente de zombi \\ 
                {
                    float tempdist = Vector3.Distance(this.transform.position, item.transform.position);
                    if (tempdist <= distmin)
                    {
                        distmin = tempdist;
                        zombimascerca = item.gameObject;
                    }
                }
                foreach (var item in FindObjectsOfType<VampiroOP>())  //  identifica todos los objetos que tengan el componente de vampiro \\
                {
                    float temdist = Vector3.Distance(this.transform.position, item.transform.position);
                    if(temdist <= distmin)
                    {
                        distmin = temdist;
                        vampimascerca = item.gameObject;
                    }
                }
                 Vector3 mivector = JugadorObjeto.transform.position - transform.position;
                 float distanciajugador = mivector.magnitude;
                if (zombimascerca != null)                                           ///-----si hay zombie cerca huye de el ----\\\
                {
                    direc = Vector3.Normalize(zombimascerca.transform.position + transform.position);
                    transform.position += direc * 0.2f;
                }
                if (vampimascerca != null)                           ///-----si hay vampiro cerca huye de el ----\\\
                {
                    direc = Vector3.Normalize(vampimascerca.transform.position + transform.position);
                    transform.position += direc * 0.2f;
                }
                 
                 if(distanciajugador <= 3.0f)                        ///-----si el jugador esta cerca da el mensaje ----\\\
                {
                    FindObjectsOfType<CiudadanoOp>();
                      textc.GetComponent<Generador>().ctext.text = "HOOOOOLA SOY  "+datoCiudadanos.genteNombres + "Y TENGO  "+ datoCiudadanos.edadgente;
                 }
                 else if (distanciajugador >= 4.0f)
                    {
                         textc.GetComponent<Generador>().Ztext.text = "";
                    }
                else                     // no hay un vampiro o zombi cerca... el cuidadano entrara a sus estados normales hasta que lo atrapen \\
                {
                    Statemovi();                   
                }

            }
            

        }

        public struct CosasCiudadanos
        {
            public enum Nombres
            {
                stubbs,
                rob,
                toreto,
                pequeñotim,
                doncarlos,
                carlosII,
                carlosI,
                sergio,
                stevan,
                tutiaentanga,
                panzerottedelsena,
                cj,
                haytevoysampedro,
                sanpeludo,
                alexisdelpeludoII,
                putoalexis,
                jason,
                andrey,
                atreus,
                artion,
                kratos,
                zeus,
                loki,
                sam,
                wilson,
                elbrayan,
                venites,
                sampedro,
            }
            public Nombres genteNombres;

           
            public int edadgente;

            public static explicit operator CosasZombie(CosasCiudadanos dgente)
            {
                CosasZombie Szombie = new CosasZombie();
                Szombie.edadzombi = dgente.edadgente;
                return Szombie;
            }
        }
    }
}

   

    

