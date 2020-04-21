using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAutos : MonoBehaviour
{
    public GameObject[] poolAutos;
    LevelManager levelManagerScript;
    public float posXMin = 1.6f;
    public float posZMin = -5f;
    public float posXMax = 7.6f;
    public float posZMax = 326f;
    public Vector3 rangoDeSpawn;

    public Transform midUno;
    public Transform midDos;
    public Transform midTres;
    public Transform midCuatro;

    public float pXMin;
    public float pXMax;
    public float pZMin;
    public float pZMax;

    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManager>();
           
    }

    private void Update()
    {
        while (levelManagerScript.cantidadAutos < levelManagerScript.autosMax)
        {
            PruebaInvokeAutosHerno();
            //InvocarAuto();
            levelManagerScript.cantidadAutos++;
            //print("cantidad de autos"+levelManagerScript.cantidadAutos);
            //print("autos max"+levelManagerScript.autosMax);
        }
    }

    //public void InvocarAuto()
    //{
    //    rangoDeSpawn = new Vector3(Random.Range(posXMin, posXMax), 0.04f, Random.Range(posZMin, posZMax));
    //    GameObject.Instantiate(poolAutos[Random.Range(0, poolAutos.Length - 1)], rangoDeSpawn, transform.rotation);
    //}

    public void PruebaInvokeAutosHerno()
    {
        pXMin = midUno.transform.lossyScale.x;
        pXMax = midUno.transform.lossyScale.x;
        
        rangoDeSpawn = new Vector3(Random.Range(pXMin, pXMax) ,0.04f, Random.Range(1f, 95f));
        GameObject.Instantiate(poolAutos[Random.Range(0, poolAutos.Length - 1)], rangoDeSpawn, transform.rotation);
    }


}
