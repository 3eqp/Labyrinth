﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int nowHealth;
    private int maxHealth = 200;
    private int minHealth = 0;
    private int speedOfdischarge = 1;
    private new Renderer[] renderer;

    public int Healths
    {
        get { return nowHealth;}
        set
        {
            nowHealth = Mathf.Clamp(value, minHealth, maxHealth);
            Material newmaterial = renderer[0].material;
            Color newcolor;
            if (nowHealth >= 100) newcolor = new Color(Persent(200, 100, nowHealth), 1, 0);
            else newcolor = new Color(1, Persent(0, 100, nowHealth), 0);
            newmaterial.color = newcolor;
            foreach (Renderer m in renderer)
            {
                m.material = newmaterial;
            }
            
        }
    }

    private void Start()
    {        
        renderer = GetComponentsInChildren<Renderer>();
        Healths = maxHealth;
        StartCoroutine(TimerOfButttery());
    }
    IEnumerator TimerOfButttery()
    {
        yield return new WaitForSeconds(speedOfdischarge);
        Buttary();
    }

    void Buttary()
    {
        Healths -= 10;
        if (Healths <= 0) Dead();
        else StartCoroutine(TimerOfButttery());
    }

    void Dead()
    {
        GetComponent<MovePlayer>().enabled = false;
        print("триггер вызывается");
        GetComponent<Animator>().SetTrigger("dead");
        GetComponent<Health>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
    }


    float Persent(float min, float max, float value)
    {
        return Mathf.Abs((min - value) / (max - min));
    }


    
}

