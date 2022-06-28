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

    List<GameObject> zombies = new List<GameObject>();
    static GFRDMakeZombie instance;
    static int currentIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < ZombieCountPerSpawn; ++i)
        {
            var instanced = GameObject.Instantiate(zombiePrefab);
            zombies.Add(instanced);

            instanced.transform.position = zombieStart.transform.position;

            var random = Random.insideUnitCircle * 2f;
            var pos = instanced.transform.position;
            pos.x += random.x;
            pos.z += random.y;

            instanced.transform.position = pos;
        }
    }

    public static GameObject GetZombie()
    {
        var ret = instance.zombies[currentIndex]; // currentIndex = 0, 1
        currentIndex++; // currentIndex = 1
        if (currentIndex >= instance.zombies.Count) // count = 1, 1 > 1 == false
            currentIndex = 0;

        // cur == 1
        return ret;
    }
}
