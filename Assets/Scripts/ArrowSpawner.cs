using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;
    public Transform shootingPoint;
    public float force = 30f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootArrow", 4f, Random.Range(2f, 5f));
    }

    public void ShootArrow()
    {
        GameObject iArrow = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
        iArrow.GetComponent<Rigidbody>().AddForce(this.transform.right * force, ForceMode.Impulse);
    }
}
