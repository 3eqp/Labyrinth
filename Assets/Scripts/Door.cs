using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool beOpened = false;

    [SerializeField]
    GameObject myKey;

    void Update()
    {
        if(beOpened)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            if (transform.position.y < -6) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Card"))
        {
            beOpened = true;
            myKey.GetComponent<Renderer>().enabled = true;
            Destroy(other.gameObject);
        }
    }
    
}
