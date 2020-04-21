using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPolicia : MonoBehaviour
{
    public float cooldown = 0f;
    public float cooldownTimer=15f;
    public GameObject policia;
    public Transform [] posiciones;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
        
    }


    public void Crear()
    {

        index = Random.Range(0, posiciones.Length);
        Instantiate(policia, posiciones[index].transform.position, posiciones[index].transform.rotation);
    }

    public void Cooldown()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 10;
            Crear();
        }
    }

}
