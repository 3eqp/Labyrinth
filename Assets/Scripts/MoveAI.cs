using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    
    NavMeshAgent botagent; // ссылка на агент навигации
    Animator animbot; // ссылка на аниматор бота
   
    enum states
    {
        waiting, // ожидает
        going,
        underitem
    }

    states state = states.waiting; // изначальное состояние ожидания

    void Start()
    {
        animbot = GetComponent<Animator>(); // берем компонент аниматора
        botagent = GetComponent<NavMeshAgent>(); // берем компонент агента
        StartCoroutine(Wait()); // запускаем корутину ожидания
    }

    private void Update()
    {
        if(state == states.going)
        {
            float distance = Vector3.Distance(transform.position, botagent.destination);
            if (distance<25f)
            {
                botagent.speed = 5f;
                animbot.SetBool("run", false); // останавливаем анимацию ходьбы
                animbot.SetBool("crouch", true); // останавливаем анимацию ходьбы 
                state = states.underitem;
               
            }
            
        }
        else if(state == states.underitem)
        {
            float distance = Vector3.Distance(transform.position, botagent.destination);
            if (distance < 1f)
            {
                print("запускаем корутину снова");
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()//корутина ожидания
    {

        botagent.ResetPath(); // обнуляем точку, чтобы бот никуда не шёл
        animbot.SetBool("walk", false); // останавливаем анимацию ходьбы
       
        state = states.waiting; // указываем, что бот перешел в режим ожидания

        yield return new WaitForSeconds(5f); // ждем 10 секунд

        
        botagent.SetDestination(GetPoint()); // destination – куда идти боту, передаем ему рандомно одну из наших точек
        botagent.speed = 20f;
        animbot.SetBool("crouch", false); // останавливаем анимацию ходьбы    
        animbot.SetBool("walk", true); // останавливаем анимацию ходьбы
        animbot.SetBool("run", true); // включаем анимацию ходьбы
        state = states.going; // указываем, что бот находится в движении  
    }

    Vector3 GetPoint()
    {
        while (true)
        {
            int random4ik = Random.Range(0, MainManager.allpoints.Length);
            if (MainManager.allpoints[random4ik] != null)
            {
                print("получил новую точку" + MainManager.allpoints[random4ik].position);
                return MainManager.allpoints[random4ik].position;
                
            }
        }

    }

}


