using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFRDMap : MonoBehaviour
{
    [SerializeField]
    int mapSizeX, mapSizeY;

    // Start is called before the first frame update
    [SerializeField]
    GameObject mapTilePrefab;
    void Start()
    {
        for(int i = 0; i < mapSizeY; ++i)
        {
            for (int k = 0; k < mapSizeX; ++k)
            {
                var instanced = GameObject.Instantiate(mapTilePrefab);
                instanced.transform.position = new Vector3(k * 1, 0, i * 1); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
