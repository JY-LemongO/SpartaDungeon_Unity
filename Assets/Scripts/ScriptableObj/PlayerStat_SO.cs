using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stat", fileName ="Class_")]
public class PlayerStat_SO : ScriptableObject
{
    public Sprite sprite;

    public string displayClassName;
    public string displayDesc;

    public int lv;
    public int hp;
    public int mp;

    public float atk;
    public float def;

    public int exp;
    public int gold;    
}
