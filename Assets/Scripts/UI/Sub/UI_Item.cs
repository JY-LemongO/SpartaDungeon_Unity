using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : UI_Base
{
    enum Buttons
    {
        UI_Item,
    }

    enum Images
    {
        Item_Image,
        Equip_Image,
    }

    private Item_SO currentItem = null;

    public override void Init()
    {
        base.Init();

        
    }

    public void Setup(Item_SO item)
    {
        if (item == null)
            return;

        BindButton(typeof(Buttons));
        BindImage(typeof(Images));

        GetButton((int)Buttons.UI_Item).onClick.AddListener(() => { if (currentItem) Managers.UI.ShowPopupUI<UI_ItemInfo>(); });

        currentItem = item;
        Image itemImage = GetImage((int)Images.Item_Image);
        itemImage.sprite = item.icon;
        itemImage.enabled = true;
    }
}
