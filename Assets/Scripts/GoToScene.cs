using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
   public GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void IrAEscena(string nameScene)
    {
        gameManager.Reintentar(nameScene);       
    }

    public void CargarNivel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

}
