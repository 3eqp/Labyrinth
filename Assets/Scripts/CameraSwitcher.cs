using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraSwitcher : NetworkBehaviour
{
   
    Camera camera;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        if (!isLocalPlayer) camera.enabled = false;      
    }

}
