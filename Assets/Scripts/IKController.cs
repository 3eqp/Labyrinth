using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{    
    Animator anim;

    bool near;
    Vector3 posForIK;
    float weight = 0f;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (near)
        {
            if (weight < 1) weight += 0.01f;
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(posForIK);
        }
        else if (weight > 0)
        {
            weight -= 0.01f;
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(posForIK);
        }
    }

    private void OnTriggerEnter(Collider other)//это триггер перса
    {
        if (other.CompareTag("item"))
        {
            print("object was detected"); 
            
            posForIK = other.transform.position;
            near = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        near = false;
    }
}
