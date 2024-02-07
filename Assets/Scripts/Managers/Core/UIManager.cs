using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject("@UI_Root");
            return root;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.RM.Instantiate(name, Root.transform);
        T scene = Util.GetorAddComponent<T>(go);

        return scene;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {        
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.RM.Instantiate(name, Root.transform);
        T popup = Util.GetorAddComponent<T>(go);

        _popupStack.Push(popup);

        return popup;
    }

    public void ClosePopupUI(GameObject go)
    {
        Object.Destroy(go);
    }
}
