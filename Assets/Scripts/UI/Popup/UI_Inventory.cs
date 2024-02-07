using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Popup
{
    enum GameObjects
    {
        Content,
    }

    enum Buttons
    {
        Back_Btn,
    }

    

    public override void Init()
    {
        base.Init();

        BindGameObject(typeof(GameObjects));
        BindButton(typeof(Buttons));        

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(BackToMain);

        for (int i = 0; i < Managers.Inven._slotCounts; i++)
        {
            UI_Item ui_Itme = Managers.UI.MakeSubUI<UI_Item>(parent: GetGameObject((int)GameObjects.Content).transform);
            ui_Itme.Setup(Managers.Inven.HasItems[i]);
        }            
    }

    private void BackToMain()
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_MainMenu>();
    }
}
