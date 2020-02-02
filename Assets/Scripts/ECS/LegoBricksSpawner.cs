using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBricksSpawner : MonoBehaviour
{
    public GameObject legoBrick;
    public Lego[] legosSO;
    public Vector3 spawnSize;
    public int legosNumber;
    Vector3 spawnPosition;

    void Awake()
    {
        for(int i = 0; i < legosNumber; i++)
        {
            spawnPosition = RandomPointInBox(this.transform.position, spawnSize);
            GameObject lego = Instantiate(legoBrick, spawnPosition, Random.rotation);
            lego.GetComponent<RLegoECS>().lego = legosSO[Random.Range(0, legosSO.Length)];
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
