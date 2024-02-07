using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : UI_Popup
{
    enum Buttons
    {
        Status_Btn,
        Inventory_Btn,
        Shop_Btn,
    }

    public override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Status_Btn).onClick.AddListener(OnStatus);
        GetButton((int)Buttons.Inventory_Btn).onClick.AddListener(OnInventory);
        GetButton((int)Buttons.Status_Btn);
    }

    private void OnStatus()
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_Status>();        
    }

    private void OnInventory()
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_Inventory>();
    }
}
