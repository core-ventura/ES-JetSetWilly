using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFire : MonoBehaviour
{
    float timer = 1f;
    float waitingTime = 1f;
    void OnTriggerStay(Collider collider)
    {
        timer += Time.deltaTime;
        if(timer > waitingTime) {
            timer = 0f;
            if(collider.gameObject.tag == "Player"){
                Debug.Log("Aghh, it burns!");
                collider.gameObject.GetComponentInParent<Health>().ReduceHealth();
            } else {
                collider.attachedRigidbody.AddForce(this.transform.up * Random.Range(10f,30f), ForceMode.Impulse);
            }
        }
    }
}
