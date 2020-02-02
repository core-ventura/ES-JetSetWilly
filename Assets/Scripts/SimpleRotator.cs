using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    public float speed = 60f;
    void Update()
    {
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
