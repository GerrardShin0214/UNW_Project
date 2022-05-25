using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFRDMakeZombie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject zombiePrefab;

    [SerializeField]
    GameObject zombieStart;

    public int ZombieCountPerSpawn = 5;

    private void Start()
    {
        for(int i = 0; i < ZombieCountPerSpawn; ++i)
        {
            var instanced = GameObject.Instantiate(zombiePrefab);
            instanced.transform.position = zombieStart.transform.position;

            var random = Random.insideUnitCircle * 2f;
            var pos = instanced.transform.position;
            pos.x += random.x;
            pos.z += random.y;

            instanced.transform.position = pos;
        }
    }
}
