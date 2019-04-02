using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{    
    Animator anim;

    bool near;
    Vector3 posForIK;
    float weight = 0f;

    GameObject working;    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    private void OnAnimatorIK()
    {
        if (working)
        {
            if (weight < 1) weight += 0.01f;
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(posForIK);

            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);            
            anim.SetIKPosition(AvatarIKGoal.RightHand, posForIK);          
            
        }
        else if (weight > 0)
        {
            weight -= 0.01f;
            anim.SetLookAtWeight(weight);
           // anim.SetLookAtPosition(posForIK);

            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
           // anim.SetIKPosition(AvatarIKGoal.RightHand, posForIK);
        }
    }

    private void OnTriggerEnter(Collider other)//это триггер перса
    {
        if (other.CompareTag("Buttery")||other.CompareTag("Card")|| other.CompareTag("Door"))
        {          
            working = other.gameObject;
            posForIK = working.transform.position;            
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        working = null;
    }
}
