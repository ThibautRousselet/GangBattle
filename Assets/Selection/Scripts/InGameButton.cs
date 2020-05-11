using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton : ClickableElement
{
    public override void Onclick()
    {
        base.Onclick();
    }
    public override void OnOver()
    {
        base.OnOver();
        if (Main.Instance.overedButton != null && Main.Instance.overedButton != this)
            Main.Instance.overedButton.OnLeaveOver();
        Main.Instance.overedButton = this;
    }
    public override void OnLeaveOver()
    {
        base.OnLeaveOver();
        Main.Instance.overedButton = null;
    }
}
