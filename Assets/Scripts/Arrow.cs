using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyArrow", 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && rb.velocity.magnitude > 3f) //Si choca con player y la flecha está aún moviendose...
        {
            Debug.Log("Auch! I took an arrow in the knee...");
            collision.gameObject.GetComponentInParent<Health>().ReduceHealth();
            DestroyArrow();
        }
    }

    void DestroyArrow()
    {
        Destroy(this.gameObject);
    }

}
