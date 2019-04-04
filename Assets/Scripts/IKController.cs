using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{    
    [SerializeField]
    Animator anim;
    bool changeTargets = false;
    Vector3 posForIK;
    float weight = 0f;
    GameObject working;    

    void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    private void OnAnimatorIK()
    {

        if (working && !changeTargets)
        {
            if (weight < 1) weight += 0.01f;
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(posForIK);
            print("waight is raising");
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, posForIK);

        }
        else if (weight > 0)
        {
            print("waight is lowering");
            weight -= 0.01f;
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(posForIK);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, posForIK);
        }
        else
        {
            print("weight was been lowered");
            if (working) posForIK = working.transform.position;
            changeTargets = false;
        }                 
        
    }

    public void Interaction(GameObject gameObject)
    {
        print("object was detected");
        working = gameObject;
        changeTargets = true;
    }

    public void StopInteraction()
    {
        working = null;
        changeTargets = true;
    }

    private void OnTriggerEnter(Collider other)//это триггер перса
    {
        if (other.CompareTag("Buttery") || other.CompareTag("Card") || other.CompareTag("Door")) 
        {
            Interaction(other.gameObject);
            MainManager.messenger.WriteMessage("You have found a " + other.gameObject.tag);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        StopInteraction();
    }
}
