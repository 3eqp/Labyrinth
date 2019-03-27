using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	Animator anim;
	CharacterController controller;
    static BasicPlayer Player;

    public Camera cam1;
    public Camera cam2;

    void Start ()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<BasicPlayer>();
        anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		cam1.enabled = true;
     	//cam2.enabled = false;
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("walk", true);
           // MainManager.Audio.LoopPlayStart(Player.GetComponent<AudioSource>());

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("walk", false);
            //MainManager.Audio.LoopPlayStop(Player.GetComponent<AudioSource>());
            
        }
		if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("user_anim");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!Player.isCrouch)
            {
                anim.SetBool("crouch", true);
                Player.isCrouch = true;
            }
            else
            {
                anim.SetBool("crouch", false);
                Player.isCrouch = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
            Player.playerSpeed *= 2.7f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("run", false);
            Player.playerSpeed /= 2.7f;
        }

        float x= Input.GetAxis("Horizontal");
		float z= Input.GetAxis("Vertical");

		if(z!=0) {
            Vector3 dir = transform.TransformDirection(new Vector3(0f, -3f, z*Player.playerSpeed));
			controller.Move(dir);
		}
		if(x!=0) {
            transform.Rotate(0f, x * Player.playerRotateSpeed, 0f);
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
            cam1.enabled = !cam1.enabled;
         	//cam2.enabled = !cam2.enabled;
        }
	}



}
