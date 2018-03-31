using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// 对于技能动画处理效果
    /// </summary>
    public class CharacterEventAttack : MonoBehaviour
    {
        private Animator anim;
        private CharacterAnimator characterAnim;


        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            characterAnim = GetComponentInParent<CharacterAnimator>();

        }
        //执行动画条件（加到动画播放的Event中）
        public void OnAttack()
        {
            //执行技能效果
            if(attackhandler!=null)
            {
                attackhandler();
            }
        }
        //执行取消当前动画
        public void OnCancelAnim()
        {
            characterAnim.PlayAnim(AnimatorName.idle);
        }
        public delegate void OnAttackHandler();
        public event OnAttackHandler attackhandler;
    }
}
