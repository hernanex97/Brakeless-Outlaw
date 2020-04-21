using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTransitoCalle : MonoBehaviour
{

    float posicionEnXParaInstanciar;

    public int contadorAutosPorCalle;
    public int tiempoFrecuenciaAutos;
	public int cantMaxAutos = 10;

    public GameObject[] poolSpawners;
    GameObject[] poolAutos;
    LevelManager levelManagerScript;

    Vector3 posicionAuto;

    public int anguloEnY;

    void Start()
    {
        tiempoFrecuenciaAutos = 3;
        posicionEnXParaInstanciar = poolSpawners[0].transform.position.x;
        levelManagerScript = FindObjectOfType<LevelManager>();
        poolAutos = levelManagerScript.poolAutos;


        InvokeRepeating("InvocarAuto", 1, tiempoFrecuenciaAutos);
        
    }


	public void InvocarAuto()
    {
        
		if (contadorAutosPorCalle <= cantMaxAutos)
		{
			posicionAuto = new Vector3(posicionEnXParaInstanciar, 0, poolSpawners[Random.Range(0, poolSpawners.Length)].transform.position.z);

			Quaternion anguloAuto = Quaternion.Euler(transform.rotation.x, anguloEnY, transform.rotation.z);
			GameObject.Instantiate(poolAutos[Random.Range(0, poolSpawners.Length)], posicionAuto, anguloAuto);
			contadorAutosPorCalle++; 
		}

    }


}