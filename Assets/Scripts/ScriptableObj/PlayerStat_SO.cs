using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName ="Stat", fileName ="Class_")]
public class PlayerStat_SO : ScriptableObject
{
    public Sprite sprite;

    public string displayClassName;
    public string displayName;
    [TextArea(3, 10)] public string displayDesc;

    public int lv;
    public int hp;
    public int mp;

    public float atk;
    public float def;
    
    public int gold;    
}
