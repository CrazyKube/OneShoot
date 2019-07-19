using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData{
    private int hp;                                                 //生命值
    private int damage;                                             //攻击力
    private int resistance;                                         //抗性（受控制时间）
    private int speed;                                              //速度
    private int defense;                                            //防御
    private int penetrate;                                          //穿透

    #region 
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public int Resistance
    {
        get
        {
            return resistance;
        }
        set
        {
            resistance = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }
        set
        {
            defense = value;
        }
    }

    public int Penetrate
    {
        get
        {
            return penetrate;
        }
        set
        {
            penetrate = value;
        }
    }
    #endregion
}
