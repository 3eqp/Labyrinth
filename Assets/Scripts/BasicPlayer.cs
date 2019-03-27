using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : MonoBehaviour
{
    Animator anim;

    public bool isNear { get; set; }
    public Vector3 PositionForIК { get; set; }

    public bool isTake { get; set; }
    public static bool isDrop { get; set; }

    public GameObject TakenObj { get; set; }

    public bool isCrouch { get; set; }

    public float playerSpeed = 0.15f;
    public float playerRotateSpeed = 5f;

    float smoothWeight = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        isNear = false;
        isCrouch = false;
        isDrop = false;
    }

    void Update() {
        OnAnimatorIK();
        if (isDrop){
            DropItem();
        }
        if (Input.GetMouseButton(0)) {
            if (isNear) {
                anim.SetBool("crouch", true);
            }
            if (isTake) {
                DropItem();
            }
        }

    }

    void OnAnimatorIK() {
        if (isNear) {
            if (smoothWeight < 1) smoothWeight += 0.01f;
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, smoothWeight);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PositionForIК);
            anim.SetLookAtWeight(smoothWeight);
            anim.SetLookAtPosition(PositionForIК);
        }
        else {
            if (smoothWeight > 0) smoothWeight -= 0.02f;
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, smoothWeight);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PositionForIК);
        }

        if (isTake) {
            anim.SetLookAtWeight(0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, transform.position - transform.right*2 + transform.up + transform.forward);
        }
    }

    public void DropItem() {
        Rigidbody rb = TakenObj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 20, ForceMode.Impulse);
        TakenObj.transform.parent = null;
        isTake = false;
    }

}
