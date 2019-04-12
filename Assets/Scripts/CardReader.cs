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
            door.transform.Translate(Vector3.down * Time.deltaTime * 2);
            if (door.transform.position.y < -100) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Card"))
        {
            openDoor = true;
            Destroy(other.gameObject);
            other.gameObject.transform.parent.GetComponent<Hand>().Owner.GetComponent<IKController>().StopInteraction();
            MainManager.messenger.WriteMessage("Door is unlocked!");
        }

        else if (other.CompareTag("Player"))
        {
            //other.GetComponent<IKController>().StopInteraction();
            print("кардридер без карты");
            MainManager.messenger.WriteMessage("You need a card!");
        }

    }
    
}
