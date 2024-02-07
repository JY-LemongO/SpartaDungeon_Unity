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

    private readonly int _slotCounts = 28;

    public override void Init()
    {
        base.Init();

        BindGameObject(typeof(GameObjects));
        BindButton(typeof(Buttons));        

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(BackToMain);

        for (int i = 0; i < _slotCounts; i++)
            Managers.UI.MakeSubUI<UI_Item>(parent: GetGameObject((int)GameObjects.Content).transform);
    }

    private void BackToMain()
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_MainMenu>();
    }
}
