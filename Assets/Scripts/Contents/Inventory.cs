using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event Action OnBuyItem;
    public event Action OnSellItem;

    public event Action OnEquipItem;
    public event Action OnUnequipItem;

    public Item_SO[] HasItems { get; private set; }

    private int _itemSlotIndex = 0;

    public readonly int _slotCounts = 28;

    public void TestInit()
    {
        Weapon_SO weapon = Resources.Load<Weapon_SO>("Scriptable/Items/Weapon_Sword");
        Armor_SO armor = Resources.Load<Armor_SO>("Scriptable/Items/Armor_Plate");
        Amulet_SO amulet = Resources.Load<Amulet_SO>("Scriptable/Items/Amulet_HolyMosiKkang");

        HasItems = new Item_SO[_slotCounts];

        HasItems[0] = weapon;
        HasItems[1] = weapon;
        HasItems[2] = armor;
        HasItems[3] = armor;
        HasItems[4] = amulet;
        HasItems[5] = amulet;
        _itemSlotIndex = 6;
    }

    // 상점에서 이루어질 것
    public void BuyItem(Item_SO item)
    {
        //HasItems.Add(item);
        //_itemSlotIndex++;

        //OnBuyItem?.Invoke();
    }

    // 인벤에서 이루어질 것
    public void SellItem(Item_SO item)
    {
        //if (HasItems.Count == 0)
        //{
        //    Debug.Log("인벤토리에 아이템이 존재하지 않습니다.");
        //    return;
        //}
        //if (!HasItems.Contains(item))
        //{
        //    Debug.Log("해당 아이템이 존재하지 않습니다.");
        //    return;
        //}

        //HasItems.Remove(item);
        //_itemSlotIndex--;

        //OnSellItem?.Invoke();
    }

    public void EquipItem()
    {
        OnEquipItem?.Invoke();
    }

    public void UnequipItem()
    {
        OnUnequipItem?.Invoke();
    }
}
