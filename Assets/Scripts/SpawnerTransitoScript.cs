using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTransitoScript : MonoBehaviour
{
    [Header("Autos de la Avenida Variables")]

    public GameObject[] poolAutos;
    LevelManager levelManagerScript;
    public int anguloEnY;
    Vector3 posicionAuto;
    public enum ComoSpawnear
    {
        invocarEnAvenida,
        invocarEnAvenidaInverso,
        invocarEnDerecha,
        invocarEnIzquierda,
        invocarIniciales
    }
    public ComoSpawnear comoSpawnear;

    [Header("Autos de la Avenida Variables")]
    public float distanciaCalle;
	public float cantidadMetrosSeparacion;
	public float cantidadAutosEnCarril;
    public float posicionEnZParaInstanciar;
    public int contadorAutos;
    public GameObject[] poolSpawners;

    [Header("Autos de los Costados Variables")]
    public int contadorAutosPorCalle;
    public int tiempoFrecuenciaAutos;
    public int cantMaxAutos = 10;
    //public GameObject[] poolSpawnersCostado;
    float posicionEnXParaInstanciar;


    void Start()
    {
        //FUNCION PARA LLAMAR A LOS HIJOS DE CADA SPAWNER SIN TENER QUE ARRASTRARLOS EN LA ESCENA
        poolSpawners = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            poolSpawners[i] = gameObject.transform.GetChild(i).gameObject;
        }


        levelManagerScript = FindObjectOfType<LevelManager>();
        poolAutos = levelManagerScript.poolAutos;
        //Costado spawns...
        tiempoFrecuenciaAutos = 3;
        //Avenida spawns...
        cantidadAutosEnCarril = distanciaCalle / cantidadMetrosSeparacion;
        WhereChooseSpawn();
    }

    public void FixedUpdate()
    {
        

    }

    public void InvocarAutoEnAvenida()
    {
        if (levelManagerScript.cantidadAutos< levelManagerScript.autosMax)
        {
            if(poolSpawners.Length > 0) { 
                posicionEnZParaInstanciar = poolSpawners[0].transform.position.z;
                posicionAuto = new Vector3(poolSpawners[Random.Range(0, poolSpawners.Length)].transform.position.x, 0, posicionEnZParaInstanciar);
                Quaternion anguloAuto = Quaternion.Euler(transform.rotation.x, anguloEnY, transform.rotation.z);
                GameObject autoClon = GameObject.Instantiate(poolAutos[Random.Range(0, poolAutos.Length)], posicionAuto, anguloAuto);
                autoClon.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    public void InvocarAutoEnCostado()
    {
        if (poolSpawners.Length > 0)
        {
            if (levelManagerScript.cantidadAutos < levelManagerScript.autosMax)
            {

                posicionEnXParaInstanciar = poolSpawners[0].transform.position.x;
                posicionAuto = new Vector3(posicionEnXParaInstanciar, 0, poolSpawners[Random.Range(0, poolSpawners.Length)].transform.position.z);
                Quaternion angulo = Quaternion.Euler(transform.rotation.x, anguloEnY, transform.rotation.z);
                GameObject autoClon = GameObject.Instantiate(poolAutos[Random.Range(0, poolAutos.Length)], posicionAuto, angulo);
                autoClon.transform.SetParent(this.gameObject.transform);
            }
        }
    }
    
    public void InvocarAutoInicial()
    {
        if (poolSpawners.Length > 0)
        {
            //Crear spawners autos iniciales
            if (levelManagerScript.cantidadAutos < levelManagerScript.autosMax)
            {
                posicionEnXParaInstanciar = poolSpawners[0].transform.position.x;
                posicionAuto = new Vector3(posicionEnXParaInstanciar, 0, poolSpawners[Random.Range(0, poolSpawners.Length)].transform.position.z);
                Quaternion angulo = Quaternion.Euler(transform.rotation.x, anguloEnY, transform.rotation.z);
                GameObject autoClon = GameObject.Instantiate(poolAutos[Random.Range(0, poolAutos.Length)], posicionAuto, angulo);
                autoClon.transform.SetParent(this.gameObject.transform);
            }
        }
    }






    public void WhereChooseSpawn()
    {
        switch (comoSpawnear)
        {
            case ComoSpawnear.invocarEnAvenida:
                    InvokeRepeating("InvocarAutoEnAvenida", 1, tiempoFrecuenciaAutos);
                    levelManagerScript.cantidadAutos++;
                    contadorAutos++;
                break;

            case ComoSpawnear.invocarEnAvenidaInverso:
                InvokeRepeating("InvocarAutoEnAvenida", 1, tiempoFrecuenciaAutos);
                levelManagerScript.cantidadAutos++;
                contadorAutos++;
                break;

            case ComoSpawnear.invocarEnDerecha:
                InvokeRepeating("InvocarAutoEnCostado", 1, tiempoFrecuenciaAutos);
                break;

            case ComoSpawnear.invocarEnIzquierda:
                InvokeRepeating("InvocarAutoEnCostado", 1, tiempoFrecuenciaAutos);
                break;
        }
    }

}
