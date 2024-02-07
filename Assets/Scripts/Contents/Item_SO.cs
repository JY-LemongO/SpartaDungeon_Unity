using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "Item_")]
public class Item_SO : ScriptableObject
{
    [SerializeField] int id;

    [SerializeField] Sprite icon;

    [SerializeField] int atk;

}
