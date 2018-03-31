using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Character
{
    /// <summary>
    /// 角色通过EacsyTouch移动
    /// </summary>
    public class CharacterMotor : MonoBehaviour
    {
        private  CharacterState state;
        private  CharacterAnimator characterAnim;
        private Rigidbody chRigidbody;
        private CharacterController characterControl;
        private  AnimatorStateInfo info;
        // Use this for initialization
        public void Start()
        {
            state = GetComponent<CharacterState>();
            characterAnim = GetComponent<CharacterAnimator>();
            chRigidbody = GetComponent<Rigidbody>();
        }
        public virtual void Move(float hor,float ver)
        {
            info = characterAnim.anim.GetCurrentAnimatorStateInfo(0);
            //给一个值看动画是否在Idel状态
            //if (characterAnim.anim.GetBool(AnimatorName.idle)||characterAnim.anim.GetBool(AnimatorName.run))
            if(info.IsName(AnimatorName.idle)||info.IsName(AnimatorName.run))
            {
                chRigidbody.MovePosition(chRigidbody.position + chRigidbody.transform.forward * Time.deltaTime * ver * state.moveSpeed);
                //chRigidbody.rotation*= Quaternion.AngleAxis(hor * Time.deltaTime * state.rotationSpeed, Vector3.up);
                chRigidbody.rotation*=Quaternion.AngleAxis(hor * Time.deltaTime * state.rotationSpeed, transform.up);

                characterAnim.PlayAnim(AnimatorName.run);
            }
        }
        public void OnMoveUP()
        {
            info = characterAnim.anim.GetCurrentAnimatorStateInfo(0);
            //给一个值看动画是否在Idel状态
            //if (characterAnim.anim.GetBool(AnimatorName.idle)||characterAnim.anim.GetBool(AnimatorName.run))
            if (info.IsName(AnimatorName.run))
            {
                characterAnim.PlayAnim(AnimatorName.idle);
            }
        }
    }
}
