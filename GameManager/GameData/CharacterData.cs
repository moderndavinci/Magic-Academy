using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager
{
    /// <summary>
    /// 玩家角色基础数据
    /// </summary>
    public class CharacterData
    {
        //角色名称
        public string name;
        //角色血量
        public int HP;
        //角色蓝量
        public int SP;
        //角色移动速度
        public int moveSpeed;
        //角色旋转速度
        public int rotationSpeed;
        //角色经验值
        public int experience;
        //角色攻击力
        public int attack;
        //角色攻击间隔
        public int attackInv;
        //角色攻击距离
        public int attackRange;
        //角色发现敌人距离
        public int targetRange;
        //技能一
        public int skill01;
        //技能二
        public int skill02;
        //技能三
        public int skill03;
        //技能四
        public int skill04;
    }
}
