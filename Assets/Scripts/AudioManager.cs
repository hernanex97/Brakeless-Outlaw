using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    private AudioSource audioSource;
    public AudioClip clipBackground;

    void Awake()//Inicializa scripts/variables que lo van a utilizar por ejemplo Start. Primero pasa por todos los Awake.
    {
        if (Instance == null)
        {
            Instance = this; //this, hace referencia a este script.
            DontDestroyOnLoad(gameObject);// No te destruyas, a este objeto.El objeto seria el que contiene el script.

        }
        else
        {
            Destroy(gameObject);

        }

        audioSource = GetComponent<AudioSource>();
        playBackground(clipBackground);

    }


    public void playBackground(AudioClip clip)
    {
        //audioSource.clip = clip;
        //audioSource.Play();

        audioSource.PlayOneShot(clip, 0.1f);
    }

    public void playSonido(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);

    }

    public void playSonido(AudioClip clip,float volumen)
    {
        audioSource.PlayOneShot(clip, volumen);

    }


}
