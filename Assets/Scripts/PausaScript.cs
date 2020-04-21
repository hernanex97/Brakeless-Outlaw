 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausaScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static PausaScript Instance;
    Canvas canvas;

    private void Awake()
    {
        //Si solo hay un GM, no te destruyas.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        //Si hay otro GM, destruite.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    

    private void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (GameIsPaused)
            {
                Resume();    
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        canvas.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        canvas.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToMenuScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
