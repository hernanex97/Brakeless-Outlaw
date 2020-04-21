using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public UI ui;
    public static GameManager instance;

    void Awake()//Inicializa scripts/variables que lo van a utilizar por ejemplo Start. Primero pasa por todos los Awake.
    {
        if (instance == null)
        {
            instance = this; //this, hace referencia a este script.
            DontDestroyOnLoad(gameObject);// No te destruyas, a este objeto.El objeto seria el que contiene el script.

        }
        else
        {
            Destroy(gameObject);

        }
    }
        // Start is called before the first frame update
    void Start()
    {

        ui = FindObjectOfType<UI>().GetComponent<UI>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reintentar(string nameScene)
    {
        Time.timeScale = 1f;
        ui.score.text = "Score";
        SceneManager.LoadScene(nameScene);
        

    }
}
