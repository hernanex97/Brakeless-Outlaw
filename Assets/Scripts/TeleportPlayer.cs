using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [Header ("Objeto a Telentransportar")]
    public GameObject player;

    [Header("Teleports")]
    public GameObject TeleportDestino;

    public BoxCollider playerTPCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTPCollider = player.GetComponentInChildren<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            print("tp");
            playerTPCollider.enabled = false;
            player.transform.position = new Vector3(TeleportDestino.transform.position.x, player.transform.position.y, player.transform.position.z);

            Invoke("EncenderCollderTP", 1f);
        }
    }

    public void EncenderCollderTP()
    {
        playerTPCollider.enabled = true;
    }
    
}
