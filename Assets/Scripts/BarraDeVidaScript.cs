using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaScript : MonoBehaviour
{
    public Image barraVerde;
    Vida vidaScript;
    public float vidaMax;
    public float vidaActual;
    

    void Start()
    {
        vidaScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        vidaMax = vidaScript.vida;
    }

    // Update is called once per frame
    void Update()
    {
        vidaActual = vidaScript.vida;
        barraVerde.fillAmount = vidaActual / vidaMax;
    }
}
