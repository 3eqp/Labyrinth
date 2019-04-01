using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int healths;
    private int maxHealth = 200;
    private int minHealth = 0;

    [SerializeField]
    Renderer[] renderer;
        
    public int Healths
    {
        get { return healths;}
        set
        {
            healths = Mathf.Clamp(value, minHealth, maxHealth);
            Material newmaterial = renderer[0].material;
            Color newcolor;
            if (healths >= 100) newcolor = new Color(Persent(200, 100, healths), 1, 0);
            else newcolor = new Color(1, Persent(0, 100, healths), 0);
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
    }

    float Persent(float min, float max, float value)
    {
        return Mathf.Abs((min - value) / (max - min));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("click was operating");
            Healths -= 10;
            print("здоровье сейчас " + Healths);
        }
    }
}

