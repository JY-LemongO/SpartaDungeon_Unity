using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemInfo : UI_Popup
{
    enum Buttons
    {
        Cancel_Btn,
    }

    public override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Cancel_Btn).onClick.AddListener(ClosePopupUI);
    }
}
