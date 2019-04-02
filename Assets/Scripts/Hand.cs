using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    Health health;

    [SerializeField]
    Animator anim;

    public bool HaveACard { get; private set; }   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Buttery"))
        {
            health.Healths += 100;
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("Card"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
            collision.gameObject.transform.position = gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            HaveACard = true;
            print("карта подобрана");
        }
    }

  

}
