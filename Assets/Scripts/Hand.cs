using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public GameObject Owner;//the owner of the hand

    Health health;
    Animator anim;
    IKController iK;

    private void Start()
    {
        anim = Owner.GetComponent<Animator>();
        health = Owner.GetComponent<Health>();
        iK = Owner.GetComponent<IKController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.CompareTag("Buttery"))
        {
            health.Healths += 100;
            Destroy(obj);
        }

        else if(obj.CompareTag("Card"))
        {
            obj.transform.parent = gameObject.transform;//changed the parent of the card
            obj.transform.localPosition = new Vector3(-0.00125f, 0.00374f, 0.00056f);
            obj.transform.localEulerAngles = new Vector3(200, -100, 100);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            iK.StopInteraction();           
            print("карта подобрана");
        }

        else if (collision.gameObject.CompareTag("CardReader"))
        {
            iK.StopInteraction();
        }
    }

  

}
