using Sirenix.OdinInspector;
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
        MakeMap();
    }

    void MakeMap()
    {
        // 자식 가져와서 전부 부숨
        for(int i = 0; i < transform.childCount; ++i)
        {
            var child = transform.GetChild(0);
            Destroy(child);
        }

        for (int i = 0; i < mapSizeY; ++i)
        {
            for (int k = 0; k < mapSizeX; ++k)
            {
                var instanced = GameObject.Instantiate(mapTilePrefab, this.transform);
                instanced.transform.position = new Vector3(k * 1, 0, i * 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    void Test()
    {
        MakeMap();
    }
}
