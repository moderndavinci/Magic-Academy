using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// 动画切换
    /// </summary>
    public class CharacterAnimator : MonoBehaviour
    {
        public Animator anim;
        //动画切换
        [HideInInspector]
        public  string defultName;
        [HideInInspector]
        public  string lastName;
        // Use this for initialization
        void Start()
        {
            //在其子物体上查找相应的组件
            anim = GetComponent<Animator>();
            defultName = lastName=AnimatorName.idle;
        }
        /// <summary>
        /// 切换动画
        /// </summary>
        /// <param name="nextName">下一个要播放的动画</param>
        public void PlayAnim(string nextName)
        {
            anim.SetBool(lastName,false);
            lastName = nextName;
            anim.SetBool(lastName,true);
        }
        /// <summary>
        /// 设置动画播放
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="active">If set to <c>true</c> active.</param>
        public void SetBoolAnim(string name,bool active)
        {
            anim.SetBool(name,active);
        }
    }
}
