using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public bool playerVivo = true;
    public int tiempo;
    public Text score;
    public Text textoContadorPolicias;
    int contadorPolicias;

    void Start()
    {
        playerVivo = true;
        tiempo = 0;
        StartCoroutine(Score());
    }

    void Update()
    {
        contadorPolicias = FindObjectsOfType<Policia>().Length;

        textoContadorPolicias.text = "Polis: " + contadorPolicias.ToString();
            
        score.text = "SCORE: " + tiempo.ToString();
        
    }


    IEnumerator Score()
    {
       
        while (playerVivo) {
        yield return new WaitForSeconds(1f);
            tiempo++;
        }
    }
}
