using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelShopButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        ShopPanel panel = GetComponentInParent<ShopPanel>();
        Player player = Main.Instance.CurrentPlayer;

        panel.hq.UpdateDisplay();
        foreach (ChoicePanel pan in panel.listPanels)
        {
            pan.Reset();
        }

        Main.Instance.phase = GamePhase.Normal;

        panel.gameObject.SetActive(false);
    }

}
