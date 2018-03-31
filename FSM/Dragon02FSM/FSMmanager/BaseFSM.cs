using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using UnityEngine.AI;
using Character;

namespace Dragon02.FSM
{
    /// <summary>
    /// NPC状态机
    /// </summary>
    public class BaseFSM : MonoBehaviour
    {
        //NPC的目标
        [HideInInspector]
        public Transform target;
        [HideInInspector]
        public CharacterState chState;
        [HideInInspector]
        public CharacterAnimator chAnim;
        [HideInInspector]
        public NavMeshAgent agent;
        /// <summary>
        /// 按照路点巡逻
        /// </summary>
        [HideInInspector]
        public List<Vector3> wayPoints;
        public int wayLenght;
        public int currentWP;

        public float stopDistance;

        /// <summary>
        /// 默认状态
        /// </summary>
        public FSMState defultState;
        public FSMStateID defultStateID;
        /// <summary>
        /// 当前状态
        /// </summary>
        public FSMState currentState;
        public FSMStateID currentStateID;
        /// <summary>
        /// 状态库
        /// </summary>
        public List<FSMState> states = new List<FSMState>();

        public void Awake()
        {
            InitState();
        }
        public void Start()
        {
            //配置当前状态
            defultState = states.Find(p => p.stateID == defultStateID);
            currentStateID = defultStateID;
            currentState = defultState;

            chState = GetComponent<EnemyState>();
            chAnim = GetComponent<CharacterAnimator>();
            agent = GetComponent<NavMeshAgent>();

            //获取路点
            Transform go = GameObject.FindWithTag("WayPoint").transform;
            wayLenght = go.childCount;
            for (int i = 0; i < wayLenght;i++)
            {
                wayPoints.Add(go.GetChild(i).position);
            }
        }

        /// <summary>
        /// 程序入口
        /// 提供  条件类所需要的所有变量
        /// 提供  状态类所需要的所有变量
        /// </summary>
        public void Update()
        {
            currentState.Resion(this);
            currentState.Action(this);
        }
        public void OnEnable()
        {
            InvokeRepeating("ChangeTarget", 0, 0.5f);
        }
        public void OnDisable()
        {
            CancelInvoke();
        }

        //public void InitState()
        //{
        //string path = "AI_01.TXT";
        //path = Application.streamingAssetsPath + "/" + path;
        //var allline=
        //}
        public void InitState()
        {
            //1.声明状态
            AttackState attack = new AttackState();
            DeadState dead = new DeadState();
            PatrolingState patroling = new PatrolingState();
            PursueState pursue = new PursueState();

            //2.添加映射

            pursue.AddMap(FSMTriggerID.ReachPlayer, FSMStateID.Attack);
            pursue.AddMap(FSMTriggerID.LosePlayer,FSMStateID.Patroling);
            pursue.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);  

            attack.AddMap(FSMTriggerID.WithOutAttackRange, FSMStateID.Pursue);
            attack.AddMap(FSMTriggerID.KilledPlayer,FSMStateID.Patroling);
            attack.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);

            patroling.AddMap(FSMTriggerID.SawPlayer, FSMStateID.Pursue);
            patroling.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);

            //3.将状态添加到状态库中
            states.Add(pursue);
            states.Add(attack);
            states.Add(patroling);
            states.Add(dead);
        }

        /// <summary>
        /// 状态切换
        /// </summary>
        /// <param name="triggerID">Trigger identifier.</param>
        public void ChangeTargetState(FSMTriggerID triggerID)
        {
            //通过条件ID找到对应的下一状态ID
            var targetStateID = currentState.GetMapTargetState(triggerID);
            //退出当前状态
            currentState.ExitState(this);
            //如果目标状态为空
            if (targetStateID == FSMStateID.None)
                //将当前状态修改为默认状态
                currentState = defultState;
            //如果目标状态ID为默认状态
            if (targetStateID == defultStateID)
                currentState = defultState;
            else
            {
                currentState = states.Find(p => p.stateID == targetStateID);
                currentStateID = currentState.stateID;
            }
            //执行当前状态的进入方法
            currentState.EnterState(this);
        }

        /// <summary>
        /// 为条件类提供切换目标的方法
        /// </summary>
        public void ChangeTarget()
        {
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null && go.GetComponent<PlayerState>().HP > 0)
            {
                target = go.transform;
            }
            else
                target = null;
        }
        /// <summary>
        /// 为条件类提供动画播放方法
        /// </summary>
        /// <param name="animName">Animation name.</param>
        public void PlayAnim(string animName)
        {
            chAnim.PlayAnim(animName);
        }
        /// <summary>
        /// 停止寻路
        /// </summary>
        public void StopPursue()
        {
            agent.enabled = false;
            agent.enabled = true;
        }
        /// <summary>
        /// 提供一个销毁方法
        /// </summary>
        /// <param name="go">Go.</param>
        /// <param name="time">Time.</param>
        public void DestoryObj(GameObject go, float time)
        {
            ObjectPool.Instance.CollectObject(go, time);
        }

    }
}
