using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayerAndroid : MonoBehaviour
{

    
    Movimiento player;
    PausaScript scriptPausa;

    void Start()
    {
        player = FindObjectOfType<Movimiento>();
        scriptPausa = FindObjectOfType<PausaScript>();
    }


    public void doblarDerecha()
    {

        player.derecha = true;
    }

    public void DejarDoblarDerecha()
    {
        player.derecha = false;
    }

    public void doblarIzquierda()
    {
        player.izquierda = true;
    }

    public void DejarDoblarIzquierda()
    {
        player.izquierda = false;
    }

    public void JuegoPausado()
    {
        scriptPausa.Pause();
    }

    public void ReanudarJuego()
    {
        scriptPausa.Resume();
    }

}
