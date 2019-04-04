using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Messenger : MonoBehaviour{
    
    [SerializeField]
    Text message;

    Coroutine RunMessage;

    private void Start()
    {
        WriteMessage("Escape from labyrinth!");
    }


    // метод для запуска корутины 
    public void WriteMessage(string text)
    {
        if (RunMessage != null) StopCoroutine(RunMessage);//проверка и остановка
        message.text = "";//очистка строки
        RunMessage = StartCoroutine(Message(text));//запуск корутины с выводом нового сообщения
    }
    
    // корутина для вывода сообщений
    IEnumerator Message(string message)
    {
        this.message.text = message;
        yield return new WaitForSeconds(4f);
        this.message.text = "";
    }

    public void Exit()
    {
        Application.Quit();
    }
}

