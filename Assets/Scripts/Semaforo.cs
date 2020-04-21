using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{



    public Estados estadoActual;
    public bool turnoSemaforo=true;



    public enum Estados
    {
        Estado1,
        Estado2,
        Estado3,
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InicioMaquinaEstado());
        estadoActual = Estados.Estado1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InicioMaquinaEstado()
    {

        while (true)
        {

            switch (estadoActual)
            {

                case Estados.Estado1:

                    yield return StartCoroutine(CREstado1());

                    break;

                case Estados.Estado2:

                    yield return StartCoroutine(CREstado2());

                    break;
                case Estados.Estado3:

                    yield return StartCoroutine(CREstado3());

                    break;


                default:

                    break;

            }
        }
    }

    IEnumerator CREstado1()
    {





        Collider[] Semaforo = GetComponentsInChildren<Collider>();
        
       
            
            Semaforo[0].enabled = false;

      
            
            Semaforo[1].enabled = true;

        
        yield return new WaitForSeconds(6f);
        estadoActual = Estados.Estado2;

    }

    IEnumerator CREstado2()
    {

        
            Collider [] Semaforo  = GetComponentsInChildren<Collider>();
        
       
      
            Semaforo[1].enabled = true;
         

        
            
            Semaforo[0].enabled = true;
            
        
        yield return new WaitForSeconds(4f);


        if (turnoSemaforo) { 
            
            turnoSemaforo = false;
            estadoActual = Estados.Estado3;
        }
        else
        {
            
            turnoSemaforo = true;
            estadoActual = Estados.Estado1;
        }


    }
    IEnumerator CREstado3()
    {


        Collider[] Semaforo = GetComponentsInChildren<Collider>();



        Semaforo[1].enabled = false;




        Semaforo[0].enabled = true;


        yield return new WaitForSeconds(6f);

        estadoActual = Estados.Estado2;
    }
}
