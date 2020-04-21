using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamara : MonoBehaviour
{
    MeshRenderer mesh;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Edificio")
        {
            mesh = other.gameObject.GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Edificio")
        {
            mesh = other.gameObject.GetComponentInChildren<MeshRenderer>();
            mesh.enabled = true;
        }
    }


}
