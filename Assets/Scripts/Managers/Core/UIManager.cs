using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    private int _order = 5;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _scene = null;

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

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubUI<T>(string name = null, Transform parent = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.RM.Instantiate($"Sub/{name}", parent);
        T sub = go.GetOrAddComponent<T>();        

        return sub;
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.RM.Instantiate($"Scene/{name}", Root.transform);
        T scene = go.GetOrAddComponent<T>();
        _scene = scene;

        return scene;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {        
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.RM.Instantiate($"Popup/{name}", Root.transform);
        T popup = go.GetOrAddComponent<T>();

        _popupStack.Push(popup);

        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
            return;

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Object.Destroy(popup.gameObject);
        _order--;
    }
}
