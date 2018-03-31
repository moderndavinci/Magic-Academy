using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerState : CharacterState
    {
        private bool isDeath =false;
        private void Start()
        {
            base.Start();
        }   
        public override void Death()
        {
            if (isDeath) return;
            if (!isDeath)
            {
                anim.PlayAnim(AnimatorName.dead);
                isDeath = true;
            }
        }

        public void Relife(){
            if (isDeath)
            {
                anim.SetBoolAnim(AnimatorName.dead , false);
                //
                //
                //
            }
        }
    }
}
