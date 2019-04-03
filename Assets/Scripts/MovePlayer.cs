using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer : NetworkBehaviour
{
    CharacterController controller;
    float moveSpeed = 0.15f;
    float rotateSpeed = 5f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (z != 0)
            {
                Vector3 dir = transform.TransformDirection(new Vector3(0f, -1f, z * moveSpeed));
                controller.Move(dir);
            }

            if (x != 0)
            {
                transform.Rotate(0f, x * rotateSpeed, 0f);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed *= 5f;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed /= 5f;
            }
        }
    }
}
