using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Slash.Unity.DataBind.Core.Data;

public class Test_Binding : Context
{
    private readonly Property<string> textLevelProperty = new Property<string>();

    public string TextLevel
    {
        get
        {
            return this.textLevelProperty.Value;
        }
        set
        {
            this.textLevelProperty.Value = value;
        }
    }

    private readonly Property<string> textHPProperty = new Property<string>();

    public Test_Binding()
    {
        TextLevel = "¤¾¤¾";
        TextHP = "1";
    }

    public string TextHP
    {
        get
        {
            return this.textHPProperty.Value;
        }
        set
        {
            this.textHPProperty.Value = value;
        }
    }










    public void HP()
    {
        this.TextHP = (int.Parse(this.TextHP) + 1).ToString();
    }

    public void Level()
    {
        this.TextLevel = "±èÁö¼ö";
    }
}
