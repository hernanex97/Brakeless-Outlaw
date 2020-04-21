using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMovVehiculos : MonoBehaviour
{
    public float velocidad;
    public float delayDestroy = 0.5f;
	public float delayDestroyExplosion = 1f;
	public GameObject explosion;
    public float posicionInicial;
    public Rigidbody rb_;

    public GameObject paredKiller;

    public GameObject tp1a;
    public GameObject tp2a;
    public GameObject tp3a;
    public GameObject tp1b;
    public GameObject tp2b;
    public GameObject tp3b;

	public GameObject transversalA; //pared izquierda
	public GameObject transversalB; //pared derecha

    public SpawnerTransitoScript spawnTransitScript;

    public int indexTP;

    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        spawnTransitScript = GetComponentInParent<SpawnerTransitoScript>();
        ObtenerTeleports();

    }

    void Update()
    {
        //transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        //ADD FORCE
        //SUMARLE EL NEGATIVO, O IMPULSE =0
    }

    private void FixedUpdate()
    {
        if (spawnTransitScript.comoSpawnear.ToString() == "invocarEnAvenida")
        {   
            rb_.velocity = new Vector3(0, rb_.velocity.y, 0) + Vector3.forward * velocidad;
            return;
        }

        if (spawnTransitScript.comoSpawnear.ToString() == "invocarEnAvenidaInverso")
        {
            rb_.velocity = new Vector3(0, rb_.velocity.y, 0) + Vector3.back * velocidad;
            return;
        }

        if(spawnTransitScript.comoSpawnear.ToString() == "invocarEnDerecha")
        {
            rb_.velocity = new Vector3(0, rb_.velocity.y, 0) + Vector3.left * velocidad;
            return;
        }

        if (spawnTransitScript.comoSpawnear.ToString() == "invocarEnIzquierda")
        {
            rb_.velocity = new Vector3(0, rb_.velocity.y, 0) + Vector3.right * velocidad;
            return;
        }

        if (spawnTransitScript.comoSpawnear.ToString() == "invocarInciciales")
        {
            rb_.velocity = new Vector3(0, rb_.velocity.y, 0) + Vector3.right * velocidad;
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        #region  Teleports //tocar acá ->
        if (other.gameObject.tag == "TP2B")
        {

            //transform.position = new Vector3(transform.position.x, transform.position.y, posicionInicial);
            //transform.position = new Vector3(tp2a.transform.position.x, transform.position.y, posicionInicial);
            transform.position = new Vector3(transform.position.x, transform.position.y, tp2a.transform.position.z);
        }

        if(other.gameObject.tag == "TP1A")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tp1b.transform.position.z);

        }

        if(other.gameObject.tag == "TP3A")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tp3b.transform.position.z);
        }

		//Teleports Transversales 

		if (other.gameObject.tag == "TransversalA")
		{
			if (transform.eulerAngles.y >= 268)
			{
                transform.position = new Vector3(transversalB.transform.position.x, transform.position.y, transform.position.z);
			}
		}

		if (other.gameObject.tag == "TransversalB")
		{
            if (transform.eulerAngles.y >= 80 && transform.eulerAngles.y <= 92)
			{
                transform.position = new Vector3(transversalA.transform.position.x, transform.position.y, transform.position.z);
			}	
		}

		#endregion

		
    
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 13)
            DestroyTransport();
    }
    public void DestroyTransport()
    {
        GameObject explosionClon = Instantiate(explosion, transform.position, transform.rotation);
        velocidad = 0f;
        Destroy(gameObject);
        Destroy(explosionClon, 2f);
    }

    public void ObtenerTeleports()
    {
        tp1a = GameObject.FindGameObjectWithTag("TP1A");	//Los de Atras
        tp2a = GameObject.FindGameObjectWithTag("TP2A");	//Los de Atras
        tp3a = GameObject.FindGameObjectWithTag("TP3A");	//Los de Atras
        tp1b = GameObject.FindGameObjectWithTag("TP1B");	//Los de Fondo
        tp2b = GameObject.FindGameObjectWithTag("TP2B");	//Los de Fondo
        tp3b = GameObject.FindGameObjectWithTag("TP3B");    //Los de Fondo

        transversalA = GameObject.FindGameObjectWithTag("TransversalA");
        transversalB = GameObject.FindGameObjectWithTag("TransversalB");
    }
}
