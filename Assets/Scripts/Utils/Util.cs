using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;

        return null;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false)where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        if (!recursive)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if(transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if(component != null)
                        return component;
                }                    
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
                if (component.name == name) 
                    return component;
        }

        return null;
    }
}
