using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoDisplay : MonoBehaviour
{
    public Lego lego;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = lego.color;
    }
}
