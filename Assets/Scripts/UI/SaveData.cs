using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public PlayerData MyPlayerData { get; set; }

    public SaveData()
    {
    }
}
[Serializable]
public class PlayerData
{
    public int MyLevel { get; set; }
    public float MyHP;
    public float MyMaxHealth;
    public float MyX;
    public float MyY;
    public float MyZ;
    public PlayerData(int level,float health,float maxHealth, Vector3 position)
    {
        this.MyLevel = level;
        this.MyHP = health;
        this.MyMaxHealth = maxHealth;
        this.MyX = position.x;
        this.MyY = position.y;
        this.MyZ = position.z;
    }
}
