using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenoDeEnemigos : MonoBehaviour
{
    float velocidadInicial;
    public float distanciaRaycast = 1.8f;
    TranslateMovVehiculos scriptPropio;
    //Acá tiene que bajar la velocidad
    private void Start()
    {
        distanciaRaycast = 1.8f;
        scriptPropio = GetComponentInParent<TranslateMovVehiculos>();
        velocidadInicial = scriptPropio.velocidad;
        
    }

    private void Update()
    {

        #region frenoSemaforo
        int layerMaskSemaforo = 1 << 9;//Aca dice que toque solo el layer 9 que es el del semaforo. (evita todas las layers menos la 9)
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distanciaRaycast, layerMaskSemaforo))
        {
  //          print(hit.collider);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) , Color.red);
            //Debug.DrawLine(transform.position, new Vector3((transform.position.x + distanciaRaycast), transform.position.y, transform.position.z),Color.red);
 //           Debug.Log("Did Hit");
            //scriptPropio.velocidad = 0;
            scriptPropio.rb_.velocity= new Vector3();
        }
        else
        {
            scriptPropio.velocidad = velocidadInicial;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) , Color.yellow);
            //Debug.DrawLine(transform.position, new Vector3((transform.position.x + distanciaRaycast), transform.position.y, transform.position.z), Color.yellow);

//            Debug.Log("Did not Hit");
        }
        #endregion


        int layerMaskAutosTransito = 1 << 10;//Aca dice que toque solo el layer 9 que es el del autoTransito. (evita todas las layers menos la 9)
        #region frenoAutos
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distanciaRaycast, layerMaskAutosTransito))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.red);

            scriptPropio.velocidad = hit.collider.GetComponent<TranslateMovVehiculos>().velocidad;

 //           Debug.Log("Frenando por el auto de adelante");            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);

//            Debug.Log("detector de freno de transito");
        }

    }
    #endregion

}
