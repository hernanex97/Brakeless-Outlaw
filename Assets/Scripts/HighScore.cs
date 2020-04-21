using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    int puntajeACopiar;
    UI puntajeUI;

    public bool reseteoScore = false;

    void Start()
    {
        puntajeUI = FindObjectOfType<UI>();
        
        highScore.text  = "BEST SCORE: " + PlayerPrefs.GetInt("Highscore", PlayerPrefs.GetInt("HighScore")).ToString();
        
    
    }

    // Update is called once per frame
    void Update()
    {
        puntajeACopiar = puntajeUI.tiempo;
       
        
        if (puntajeACopiar > PlayerPrefs.GetInt("HighScore", 0))
        {
            
            PlayerPrefs.SetInt("HighScore", puntajeACopiar);
            highScore.text = puntajeACopiar.ToString();

        }

        if (reseteoScore)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        
    }
}
