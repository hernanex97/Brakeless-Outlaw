using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida = 100;
    public int autosEnemigosDamage = 50;
    public float slowMotion = 0.25f;

    bool playerEstaVivo = true;

    public AudioClip[] clipsChoques;
    public AudioClip clipsExplosion;

    public GameObject explosionPlayer;
    public Canvas canvasMuerte;
    public Movimiento movimiento;

    private void Start()
    {
        canvasMuerte.enabled = false;
        movimiento = GetComponent<Movimiento>();
    }

    private void Update()
    {
        if (playerEstaVivo) { //Si esta vivo, preguntale la vida

            if (vida <= 0) 
            {
                playerEstaVivo = false;

                
                StartCoroutine(CorrutinaStopTime());
                Time.timeScale = slowMotion;
                Instantiate(explosionPlayer, transform.position, transform.rotation);               
                canvasMuerte.enabled = true;
               
                movimiento.enabled = false;
                AudioManager.Instance.playSonido(clipsExplosion,0.2f);
                
                GameManager gameManager=FindObjectOfType<GameManager>();//se encuentra el gamemanager para luego encontrar la ui
                gameManager.ui = FindObjectOfType<UI>();//se encuentra la ui para asignarle el valor a 0 desde el scrpit de gamemanager
                gameManager.ui.playerVivo = false;//se pone playervivo en falso para que reinice el score desde el script de la ui
            }
        }

    }

    //Daño contra el Player
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "AutosEnemigos" || other.gameObject.tag == "Policia")
        {
            vida -= autosEnemigosDamage;
            ElegirSonidoChoque();
        }

        else if(other.gameObject.layer == 12)//12 es la capa de agua
        {
            vida = 0;
            freezarCamara();

        }
        else if (other.gameObject.layer != 13)//12 es la capa de suelo
        {
            vida -= 2;
            int sonidoNumero = Random.Range(0, clipsChoques.Length);
            AudioManager.Instance.playSonido(clipsChoques[sonidoNumero], 0.05f);
           
        }

    }


    void freezarCamara() {

        var camara = GetComponentInChildren<Camera>();
        camara.transform.SetParent(camara.transform); 
    }

    public void PararElTiempo()
    {
        Time.timeScale = 0f;
    }
    
    IEnumerator CorrutinaStopTime()
    {        
        yield return new WaitForSeconds(2);
        PararElTiempo();       
    }


    public void ElegirSonidoChoque()
    {
        int sonidoNumero = Random.Range(0, clipsChoques.Length );
        if(clipsChoques[sonidoNumero] != null) { 
        AudioManager.Instance.playSonido(clipsChoques[sonidoNumero],0.1f);
        }
    }
}
