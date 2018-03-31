using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager
{
    /// <summary>
    /// 装备数据
    /// </summary>
    public class EquipData
    {
        //装备ID
        public int eqID;
        //装备名称
        public string eqName;
        //装备所需金币
        public int needCoin;
        //装备的攻击力
        public int attack;
        //装备的防御力
        public int defence;
        //装备对军队的攻击加成
        public int addAttack;
        //装备对玩家的移动加成
        public int moveSpeed;
        //装备对玩家的血量加成
        public int addHP;
    }
}
