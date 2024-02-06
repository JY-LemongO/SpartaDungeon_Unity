using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    #region Content
    PlayerInfo _player = new PlayerInfo();

    public PlayerInfo Player => Instance?._player;
    #endregion


    #region Core
    UIManager _ui = new UIManager();
    ResourceManager _resource = new ResourceManager();

    public UIManager UI => Instance?._ui;
    public ResourceManager ResourceManager => Instance?._resource;
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


        }
    }
}
