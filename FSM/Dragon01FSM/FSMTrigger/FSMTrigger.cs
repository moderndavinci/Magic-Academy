using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    /// <summary>
    /// 进行条件控制
    /// </summary>
    public abstract class FSMTrigger
    {

        public FSMTriggerID triggerID;
        public FSMTrigger()
        {
            Init();
        }
        /// <summary>
        /// 让派生类进行初始化
        /// </summary>
        protected abstract void Init();
        /// <summary>
        /// 条件检测
        /// </summary>
        /// <returns><c>true</c></returns>
        /// <param name="fsm">Fsm.</param>
        public abstract bool IsTrigger(BaseFSM fsm);
    }
}
