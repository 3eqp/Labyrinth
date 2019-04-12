using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    
    public static Messenger messenger;

    private void Awake()
    {
        messenger = GameObject.FindObjectOfType<Messenger>();
    }

}
