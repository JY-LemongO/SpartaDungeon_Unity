using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    private void Start()
    {
        Init();
    }

    public virtual void Init() { }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = type.GetEnumNames();
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];

        _objects.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            objs[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objs[i] == null)
                Debug.Log($"Faield to bind({names[i]})");
        }
    }

    protected void BindButton(Type type) => Bind<Button>(type);
    protected void BindImage(Type type) => Bind<Image>(type);
    protected void BindText(Type type) => Bind<Text>(type);


    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objs;
        if (_objects.TryGetValue(typeof(T), out objs) == false)
            return null;

        return objs[index] as T;
    }

    protected Button GetButton(int index) => Get<Button>(index);
    protected Image GetImage(int index) => Get<Image>(index);
    protected Text GetText(int index) => Get<Text>(index);
}
