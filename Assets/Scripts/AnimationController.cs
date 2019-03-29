using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	Animator anim;
    
    bool crouch = false;

    void Start ()
    {       
        anim = GetComponent<Animator>();		
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("walk", true);      
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("walk", false);          
            
        }
		
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (crouch) anim.SetBool("crouch", false);
            else anim.SetBool("crouch", true);            
            crouch = !crouch;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("run", false);            
        }

		
	}
  
    

}
