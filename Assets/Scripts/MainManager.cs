using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    
    public static Messenger messenger;
    public static Transform[] points;
    public static GameObject[] exits;
    public static Transform[] allpoints;
    
    private void Awake()
    {
        messenger = GameObject.FindObjectOfType<Messenger>();
        points = GetComponentsInChildren<Transform>();
        exits = GameObject.FindGameObjectsWithTag("CardReader");//находим выходы в сцене
        allpoints = CreatePoints();
    }
    
    Transform[] CreatePoints()//создает 
    {
        Transform[] p = new Transform[MainManager.points.Length + MainManager.exits.Length];
        int i = 0;
        foreach (Transform t in MainManager.points)
        {
            p[i++] = t;
        }
        foreach (GameObject g in MainManager.exits)
        {
            p[i++] = g.transform;
        }
        return p;
    }

}
