using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCtrl : MonoBehaviour
{
    public Animator anim;
    public Transform targetTransform;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            anim.SetTrigger("Jump");
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed",v);
        anim.SetFloat("Horizontal",h);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, targetTransform.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, targetTransform.rotation);

        anim.SetLookAtWeight(1.0f);
        anim.SetLookAtPosition(targetTransform.position);
    }
}
