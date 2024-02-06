using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject origin = Resources.Load<GameObject>($"Prefabs/{path}");
        if (origin == null)
        {
            Debug.Log($"Failed to load : {path}");
            return null;
        }
            
        GameObject go = Object.Instantiate(origin, parent);
        go.name = origin.name;

        return go;
    }
}
