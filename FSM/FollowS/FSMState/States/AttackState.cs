using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Character;

namespace Follow.FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class AttackState : FSMState
    {
        public float timer;
        protected override void Init()
        {
            stateID = FSMStateID.Attack;
        }

        public override void Action(BaseFSM fsm)
        {
            timer += Time.deltaTime;
            if (fsm.target!=null)
            {
                //朝向目标
                TransformHelper.Rotation(fsm.transform, fsm.target.position, fsm.chState.rotationSpeed);
                if (timer > fsm.chState.attackInv && fsm.target.GetComponent<EnemyState>().HP > 0)
                {
                    fsm.PlayAnim(AnimatorName.attack01);
                    //调用目标受伤方法
                    fsm.target.GetComponent<EnemyState>().OnDamage(fsm.chState.attack);
                }
            }
        }
        public override void EnterState(BaseFSM fsm)
        {
            Debug.Log("进入攻击状态");
        }
    }
}
