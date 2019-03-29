using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    CharacterController controller;
    float moveSpeed = 0.15f;
    float rotateSpeed = 5f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (z != 0)
        {
            Vector3 dir = transform.TransformDirection(new Vector3(0f, -3f, z * moveSpeed));
            controller.Move(dir);
        }

        if (x != 0)
        {
            transform.Rotate(0f, x * rotateSpeed, 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2.7f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 2.7f;
        }

    }
}
