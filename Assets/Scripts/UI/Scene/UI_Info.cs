using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Info : UI_Scene
{
    enum Texts
    {
        Gold_Text,
        Class_Text,
        Name_Text,
        Lv_Text,
        Exp_Text,
        Desc_Text,
    }

    enum Images
    {
        Exp_Image,
    }

    public override void Init()
    {
        base.Init();

        BindText(typeof(Texts));
        BindImage(typeof(Images));

        InfoInit();
    }

    private void InfoInit()
    {
        PlayerInfo info = Managers.Player;

        GetText((int)Texts.Gold_Text).text  = $"{info.Gold}";
        GetText((int)Texts.Class_Text).text = $"{info.ClassName}";
        GetText((int)Texts.Name_Text).text  = $"{info.Name}";
        GetText((int)Texts.Lv_Text).text    = $"{info.Lv}";
        GetText((int)Texts.Exp_Text).text   = $"{info.Exp} / {info.InitLeveupExp}";
        GetText((int)Texts.Desc_Text).text  = $"{info.DisplayDesc}";

        GetImage((int)Images.Exp_Image).fillAmount = (float)info.Exp / info.InitLeveupExp;
    }
}
