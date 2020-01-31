using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBall : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("ImpulseInRandomDirection", 3f, 3f);

    }

    public void ImpulseInRandomDirection()
    {
        Vector3 direction = new Vector3(Random.value, Random.value, Random.value);
        this.rb.AddForce(direction.normalized * 10f, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            Debug.Log("Ugh! Be careful Mr.Ball...");
            collision.gameObject.GetComponentInParent<Health>().ReduceHealth();
        }         
    }

}
