using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    int CountOfButtery = 5;
    int CountOfCards = 3;

    GameObject mainPlayer;
    Transform[] points;

    [SerializeField]
    GameObject buttery;

    [SerializeField]
    GameObject card;

    int[] randompoints = new int[10];

    int CountOfObject = 0;

   public void ReadyToStart()
    {
        points = GetComponentsInChildren<Transform>();
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        //Instantiate(mainPlayer, GetRandomPoint(), Quaternion.identity);
        mainPlayer.transform.position = GetRandomPoint();
        for (int i = 0; i < CountOfButtery; i++) Instantiate(buttery, GetRandomPoint(), Quaternion.identity);
        for (int i = 0; i < CountOfCards; i++) Instantiate(card, GetRandomPoint(), Quaternion.identity);
    }

    Vector3 GetRandomPoint()
    {
        int value = 0;
        bool ok = true;
        do
        {
            value = Random.Range(0, points.Length - 1);
            ok = true;
            foreach (int v in randompoints)
            {
                if (v == value)
                {
                    ok = false;
                    break;
                }
            }
            
        } while (!ok);


        randompoints[CountOfObject++] = value;
        return points[value].position;
    }


}
