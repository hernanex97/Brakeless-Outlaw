using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public Terrain terrain;
    public TerrainLayer[] splProto;
    public float xOffset;
    public float yOffset;
    public float watterSpeedX;
    public float watterSpeedY;


    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        splProto = terrain.terrainData.terrainLayers;
    }
    void Start()
    {
        //InvokeRepeating("WaterAnimation", 0, 1);
        //terrain.terrainData.splatPrototypes[2].tileOffset.x+=0.1;
    }

    void FixedUpdate()
    {
        splProto[0].tileOffset = new Vector2(xOffset++ * watterSpeedX, yOffset++ * watterSpeedY);

    }

    public void WaterAnimation()
    {
        //splProto[0].tileOffset = new Vector2(xXOffset++, xYOffset * Time.deltaTime);
    }
}
