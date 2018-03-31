using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Follow.FSM
{
    /// <summary>
    /// FSMState进行状态控制
    /// </summary>
    public abstract class FSMState
    {
        /// <summary>
        /// 状态ID
        /// </summary>
        public FSMStateID stateID;
        /// <summary>
        /// 条件列表
        /// </summary>
        public List<FSMTrigger> triggers = new List<FSMTrigger>();
        /// <summary>
        /// 条件映射表
        /// </summary>
        public Dictionary<FSMTriggerID,FSMStateID> map = new Dictionary<FSMTriggerID, FSMStateID>();
        /// <summary>
        /// 执行初始化
        /// </summary>
        public FSMState()
        {
            Init();
        }
        protected abstract void Init();

        /// <summary>
        /// 添加映射
        /// </summary>
        /// <param name="triggerID">triggerID条件ID</param>
        /// <param name="stateID">状态ID</param>
        public void AddMap(FSMTriggerID triggerID,FSMStateID stateID)
        {
            if (!map.ContainsKey(triggerID))
            {
                //添加映射
                map.Add(triggerID, stateID);
                //添加条件
                AddObjectTrigger(triggerID);
            }
            else
            {
                map[triggerID] = stateID;
            }
        }

        /// <summary>
        /// 删除相应的映射
        /// </summary>
        /// <param name="triggerID">Trigger identifier.</param>
        public void RemoveMap(FSMTriggerID triggerID)
        {
            if(map.ContainsKey(triggerID))
            {
                map.Remove(triggerID);
                RemoveObjectTrigger(triggerID);
            }
        }
        /// <summary>
        /// 添加相应条件
        /// </summary>
        /// <param name="triggerID">Trigger identifier.</param>
        public void AddObjectTrigger(FSMTriggerID triggerID)
        {
            //通过反射获取类型
            Type type = Type.GetType("Follow.FSM." + triggerID + "Trigger");
            if(type!=null)
            {
                triggers.Add(Activator.CreateInstance(type) as FSMTrigger);
            }
        }
        /// <summary>
        /// 条件列表中删除对应的条件
        /// </summary>
        /// <param name="triggerID">Trigger identifier.</param>
        public void RemoveObjectTrigger(FSMTriggerID triggerID)
        {
            triggers.RemoveAll(p=>p.triggerID==triggerID);
        }
        /// <summary>
        /// 获取映射表中的状态
        /// </summary>
        /// <returns>The map target state.</returns>
        /// <param name="triggerID">Trigger identifier.</param>
        public FSMStateID GetMapTargetState(FSMTriggerID triggerID)
        {
            if(map.ContainsKey(triggerID))
            {
                return map[triggerID];
            }
            return FSMStateID.None;
        }
        /// <summary>
        /// 状态行为
        /// </summary>
        /// <returns>The action.</returns>
        /// <param name="fsm">Fsm.</param>
        public abstract void Action(BaseFSM fsm);
        /// <summary>
        /// 检测条件
        /// </summary>
        /// <returns>The resion.</returns>
        /// <param name="fsm">Fsm.</param>
        public virtual void Resion(BaseFSM fsm)
        {
            for (int i = 0; i < triggers.Count;i++)
            {
                if(triggers[i].IsTrigger(fsm))
                {
                    fsm.ChangeTargetState(triggers[i].triggerID);
                }
            }
        }
        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="fsm">Fsm.</param>
        public virtual void EnterState(BaseFSM fsm) { }
        /// <summary>
        /// 退出状态
        /// </summary>
        /// <param name="fsm">Fsm.</param>
        public virtual void ExitState(BaseFSM fsm){ }

    }
}
