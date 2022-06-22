using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKMgr : MonoBehaviour
{
    //[SerializeField]
    //private Animator playerAnimator;
    //[SerializeField]
    //private Transform targetTransform;
    //[SerializeField]
    //private FollowCamera followCamera;
    
    //private void OnAnimatorIK(int layerIndex)
    //{
    //    Debug.Log("daf");
    //    if (followCamera.GetCamType == CamType.First)
    //    {
    //        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
    //        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);

    //        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, Input.mousePosition);
    //        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, Input.mousePosition);

    //        playerAnimator.SetLookAtWeight(1f);
    //        playerAnimator.SetLookAtPosition(Input.mousePosition);
    //    }
    //}
    Animator anim;
    [SerializeField] private Transform target;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        //target = GameObject.Find("Target").transform;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.5f);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.5f);
    }
}
