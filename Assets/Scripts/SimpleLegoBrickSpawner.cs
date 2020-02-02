using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLegoBrickSpawner : MonoBehaviour
{
    public GameObject[] legoBrick;
    public Vector3 spawnSize;
    public int legosNumber;
    Vector3 spawnPosition;

    void Awake()
    {
        for(int i = 0; i < legosNumber; i++)
        {
            spawnPosition = RandomPointInBox(this.transform.position, spawnSize);
            Instantiate(legoBrick[Random.Range(0, legoBrick.Length)], spawnPosition, Random.rotation);
        }
    }

    public Vector3 RandomPointInBox(Vector3 center, Vector3 size) {
     
        return center + new Vector3(
                (Random.value - 0.5f) * size.x,
                (Random.value - 0.5f) * size.y,
                (Random.value - 0.5f) * size.z
        );
    }
}
