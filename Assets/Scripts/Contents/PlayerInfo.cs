using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInfo
{
    enum PlayerClass
    {
        Class_Handsome,
        Class_Magician,
        Class_Pirate,
    }

    PlayerStat_SO _stat;

    public string ClassName {  get; private set; }
    public string Name { get; private set; }
    public string DisplayDesc { get; private set; }

    public int Lv { get; private set; }
    public int Hp { get; private set; }
    public int Mp { get; private set; }
    public float Atk { get; private set; }
    public float Def { get; private set; }

    public int Exp { get; private set; }
    public int Gold { get; private set; }

    public readonly int InitLeveupExp = 10;

    public void Init() // 랜덤 캐릭터 생성
    {
        string[] classNames = typeof(PlayerClass).GetEnumNames();
        string randomClass = classNames[Random.Range(0, classNames.Length)];        

        _stat = Resources.Load<PlayerStat_SO>($"Scriptable/PlayerClass/{randomClass}");

        ClassName = _stat.displayClassName;
        Name = _stat.displayName;
        DisplayDesc = _stat.displayDesc;

        Lv = _stat.lv;
        Hp = _stat.hp;
        Mp = _stat.mp;
        Atk = _stat.atk;
        Def = _stat.def;
        Gold = _stat.gold;
        
        Exp = Random.Range(0, 10);

        // 구조 변경이 필요하지만 일단 진행
        GameObject go = GameObject.Find("MainPage");
        Image character = Util.FindChild<Image>(go, "Player_Image", true);
        character.sprite = _stat.sprite;
    }
}
