using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    #region Content
    PlayerInfo _player = new PlayerInfo();
    Inventory _inven = new Inventory();

    public static PlayerInfo Player => Instance?._player;
    public static Inventory Inven => Instance?._inven;
    #endregion


    #region Core
    UIManager _ui = new UIManager();
    ResourceManager _resource = new ResourceManager();

    public static UIManager UI => Instance?._ui;
    public static ResourceManager RM => Instance?._resource;
    #endregion


    private void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }

            s_instance = go.GetComponent<Managers>();

            Player.Init();
            UI.ShowSceneUI<UI_Info>();
            UI.ShowPopupUI<UI_MainMenu>();
        }
    }
}
