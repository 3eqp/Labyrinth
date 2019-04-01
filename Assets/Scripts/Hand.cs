using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    Health health;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Buttery"))
        {
            health.Healths += 100;
            Destroy(collision.gameObject);
        }
    }
}
