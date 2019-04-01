using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int nowHealth;
    private int maxHealth = 200;
    private int minHealth = 0;
    private int speedOfdischarge = 5;
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
            print("Health was changed on " + Healths);
        }
    }

    private void Start()
    {        
        renderer = GetComponentsInChildren<Renderer>();
        Healths = maxHealth;
        InvokeRepeating("Buttary", speedOfdischarge, speedOfdischarge);
    }

    void Buttary() => Healths -= 10;

    float Persent(float min, float max, float value)
    {
        return Mathf.Abs((min - value) / (max - min));
    }


    
}

