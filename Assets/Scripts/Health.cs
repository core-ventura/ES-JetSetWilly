using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    Rigidbody rb;
    float maxhealthpoints = 8f;
    float currenthealthpoints = 8f;
    public GameObject healthPrefab;
    public Transform healthUIParent;
    public ParticleSystem blood;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        for(int i = 0; i < maxhealthpoints; i++)
        {
            GameObject life = Instantiate(healthPrefab, transform.localPosition, Quaternion.identity);
            life.transform.SetParent(healthUIParent);
            life.transform.localPosition = Vector3.zero;
        }
    }

    public void AddHealth()
    {
        if(currenthealthpoints < maxhealthpoints)
        {
            currenthealthpoints++;
            GameObject life = Instantiate(healthPrefab, transform.localPosition, Quaternion.identity);
            life.transform.SetParent(healthUIParent);
            life.transform.localPosition = Vector3.zero;
        }
    }

    public void ReduceHealth()
    {
        if(currenthealthpoints > 1)
        {
            currenthealthpoints--;
            ParticleSystem ps = Instantiate(blood, this.transform.position, Quaternion.identity);
            ps.Play();
            Destroy(healthUIParent.GetChild(0).gameObject);
        } else {
            Death();
        }        
    }

    public void Death()
    {
        FindObjectOfType<GameManager>().LoadMenuScene();
    }
}
