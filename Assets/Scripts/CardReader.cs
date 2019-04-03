using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    bool openDoor = false;

    
    GameObject door;

    private void Start()
    {
        door = transform.parent.gameObject;
    }

    void Update()
    {
        if(openDoor)
        {
            door.transform.Translate(Vector3.down * Time.deltaTime);
            if (door.transform.position.y < -6) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Card"))
        {
            openDoor = true;
            Destroy(other.gameObject);
            other.gameObject.transform.parent.GetComponent<Hand>().Owner.GetComponent<IKController>().StopInteraction();
           
        }
        
        
    }
    
}
