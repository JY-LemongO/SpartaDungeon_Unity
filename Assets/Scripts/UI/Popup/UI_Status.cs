using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Status : UI_Popup
{
    enum Buttons
    {
        Back_Btn,
    }

    enum Texts
    {
        Atk_Text,
        Def_Text,
        Hp_Text,
        Mp_Text,        
    }

    public override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(BackToMain);
    }

    private void BackToMain()
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_MainMenu>();
    }

    private void UpdateUI()
    {
        PlayerInfo info = Managers.Player;

        GetText((int)Texts.Atk_Text).text = $"{info.Atk}";
        GetText((int)Texts.Def_Text).text = $"{info.Def}";
        GetText((int)Texts.Hp_Text).text = $"{info.Hp}";
        GetText((int)Texts.Mp_Text).text = $"{info.Mp}";        
    }
}
