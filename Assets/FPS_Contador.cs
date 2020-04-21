using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS_Contador : MonoBehaviour
{
    public Text textFPS;
    public float deltaTime;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        textFPS.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }
}
