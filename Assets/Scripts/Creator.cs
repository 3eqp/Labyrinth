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

    [SerializeField]
    GameObject ai;

    int[] randompoints;

    int CountOfObject = 0;

   public void ReadyToStart()
    {
        points = GetComponentsInChildren<Transform>();
        randompoints = new int[points.Length];
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        //Instantiate(mainPlayer, GetRandomPoint(), Quaternion.identity);
        mainPlayer.transform.position = GetRandomPoint();
        for (int i = 0; i < CountOfButtery; i++) Instantiate(buttery, GetRandomPoint(), Quaternion.identity);
        for (int i = 0; i < CountOfCards; i++) Instantiate(card, GetRandomPoint(), Quaternion.identity);

        PrepairExits();
        Instantiate(ai, GetRandomPoint(), Quaternion.identity);
    }

    void PrepairExits()
    {
        GameObject[] exits = GameObject.FindGameObjectsWithTag("CardReader");//находим выходы в сцене
        int Random4ik = Random.Range(0, 3);//рандомим номер выхода
       for(int i = 0; i< exits.Length;i++)
        {
            if (i != Random4ik) Destroy(exits[i]);//удаляем все выходы кроме выпавшего рандомно
            else exits[i].transform.parent.tag = "Door";//устанавливаем родителю выбранного выхода тэг для открытия
        }
    }

    Vector3 GetRandomPoint()//рандом с проверкой на занятые ячейки
    {
        
        if (points.Length == CountOfObject)
        {
            print("больше нет свободных ячеек");
            return new Vector3(0, 0, 0);
        }

        int value;
        while (true)
        {
            value = Random.Range(0, randompoints.Length);
            if(randompoints[value]==0)
            {
                randompoints[value] = ++value;
                return points[--value].position;
            }
        }
        
        
    }


}
