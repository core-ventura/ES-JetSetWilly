using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallAnimated : MonoBehaviour
{
    Animator animator;
    Vector3 startingPosition;
    Vector3 finalPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startingPosition = this.transform.localPosition;
        finalPosition = new Vector3(startingPosition.x, startingPosition.y + 5f, startingPosition.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition.y == startingPosition.y)
        {
            animator.SetBool("goingUp", true);
        }

        if (this.transform.localPosition.y == finalPosition.y)
        {
            animator.SetBool("goingUp", false);
        }
    }
}
