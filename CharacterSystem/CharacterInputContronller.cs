using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// 玩家输入控制类
    /// </summary>
    [RequireComponent(typeof(PlayerState))] //连接这两个类
    [RequireComponent(typeof(PlayerMotor))]
    public class CharacterInputContronller : MonoBehaviour
    {
        //技能系统
        private CharacterSkillSystem chSkillsystem;
        //玩家马达
        private CharacterMotor chMotor;
        //玩家状态
        private CharacterState chState;
        //输入控制器
        private ETCJoystick joystickMove;
        private ETCButton mAttack01;
        private ETCButton mAttack02;
        private ETCButton mAttack03;
        private ETCButton mAttack04;

        private void Start()
        {
            chSkillsystem = GetComponent<CharacterSkillSystem>();
            chMotor = GetComponent<CharacterMotor>();
            chState = GetComponent<CharacterState>();

            joystickMove = ETCInput.GetControlJoystick("JoystickMove");
            mAttack01 = ETCInput.GetControlButton("Attack01");
            mAttack02 = ETCInput.GetControlButton("Attack02");
            mAttack03 = ETCInput.GetControlButton("Attack03");
            mAttack04 = ETCInput.GetControlButton("Attack04");
            //为按键绑定当前技能执行的动画效果（动画中使技能的执行）
            joystickMove.onMove.AddListener(OnMove);
            joystickMove.onMoveEnd.AddListener(OnMoveUP);
            mAttack01.onDown.AddListener(Attack01);
            mAttack02.onDown.AddListener(Attack02);
            mAttack03.onDown.AddListener(Attack03);
            mAttack04.onDown.AddListener(Attack04);
        }
        //移动
        public void OnMove(Vector2 value)
        {
            chMotor.Move(value.x,value.y);
        }
        //取消移动
        public void OnMoveUP()
        {
            chMotor.OnMoveUP();
        }
        //释放技能一
        public void Attack01()
        {
            chSkillsystem.AttackUseSkill(5,false);
        }
        //释放技能二
        public void Attack02()
        {
            chSkillsystem.AttackUseSkill(6,false);
        }
        //释放技能三
        public void Attack03()
        {
            chSkillsystem.AttackUseSkill(7,false);
        }
        //释放技能四
        public void Attack04()
        {
            chSkillsystem.AttackUseSkill(8,false);
        }


    }
}
