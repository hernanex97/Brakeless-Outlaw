using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Policia : MonoBehaviour
{
    public float velocidad = 4f;
    public bool siguiendo = true;
    public float rangoDeteccion = 10f;
    public float rangoAtaque = 1.5f;
    public AudioClip sirena;
    Vida personaje;
    NavMeshAgent agent;
    Rigidbody rb;
    public float cooldownTimer;
    public int idPolice;


    public Estados estadoActual;



    public enum Estados
    {
        EstadoLuzAzulPrendido,
        EstadoLuzRojoPrendido,
    }


    void Start()
    {

        StartCoroutine(InicioMaquinaEstadoDeLuces());
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        personaje = FindObjectOfType<Vida>();
        estadoActual = Estados.EstadoLuzAzulPrendido;
        agent.speed = velocidad;
        idPolice = Random.Range(0, 2);

    //SonidoSierna();
    }

    void FixedUpdate()
    {


        float distanciaAlPersonaje = Vector3.Distance(transform.position, personaje.transform.position);

        if (idPolice == 1)
        {
            if (distanciaAlPersonaje > rangoAtaque)//Si el enemigo esta lejos del pj entonces solo lo sigo
            {
                Vector3 destino = personaje.transform.position + Vector3.forward * distanciaAlPersonaje; //hace que los polis te cruzen foerte
                agent.destination = destino;//NavMeshAgent.Warp(personaje.transform.position);//
            }
        }
        if (idPolice == 0)
        {
            if (distanciaAlPersonaje > rangoAtaque)//Si el enemigo esta lejos del pj entonces solo lo sigo
            {
                Vector3 destino = personaje.transform.position * distanciaAlPersonaje; //hace que los polis te cruzen foerte
                agent.destination = personaje.transform.position; ;//NavMeshAgent.Warp(personaje.transform.position);//
            }
        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }

    public void SonidoSierna()
    {
        AudioManager.Instance.playSonido(sirena, 0.3f);
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == 12) //El layer 12 es el Agua

        {

            Destroy(this);
        }
    }

    IEnumerator InicioMaquinaEstadoDeLuces()
    {
        while (true)
        {
            switch (estadoActual)
            {
                case Estados.EstadoLuzAzulPrendido:
                    yield return StartCoroutine(CorrutinaLuzAzulPrendido());
                    break;

                case Estados.EstadoLuzRojoPrendido:
                    yield return StartCoroutine(CorrutinaLuzRojoPrendido());
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator CorrutinaLuzAzulPrendido()
    {
        Light LuzAzul = GetComponentInChildren<Light>();
        if (LuzAzul.tag == "LuzAzul")
        {
            LuzAzul.intensity = 10;
        }
        if (LuzAzul.tag == "LuzRoja")
        {
            LuzAzul.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        estadoActual = Estados.EstadoLuzRojoPrendido;
    }

    IEnumerator CorrutinaLuzRojoPrendido()
    {
        Light LuzRoja = GetComponentInChildren<Light>();
        if (LuzRoja.tag == "LuzRoja")
        {
            LuzRoja.intensity = 10;
        }
        if (LuzRoja.tag == "LuzAzul")
        {
            LuzRoja.intensity = 0;
        }
        yield return new WaitForSeconds(1f);

        estadoActual = Estados.EstadoLuzAzulPrendido;
    }
}
