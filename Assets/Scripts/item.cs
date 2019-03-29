using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//это триггер перса
    {
        if (other.CompareTag("Player"))
        {
            print("object was detected");
           // anim.SetLookAtWeight(1f);
            //posForIK = other.transform.position;
            //near = true;
        }
    }

}
