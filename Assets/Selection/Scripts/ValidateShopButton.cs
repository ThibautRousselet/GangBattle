using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateShopButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        ShopPanel panel = GetComponentInParent<ShopPanel>();
        Player player = Main.Instance.CurrentPlayer;

        player.Credits -= panel.TotalCost;
        panel.hq.NbTroops += panel.listPanels[0].value;
        panel.hq.UpdateDisplay();
        foreach (ChoicePanel pan in panel.listPanels)
        {
            pan.Reset();
        }

        Main.Instance.phase = GamePhase.Normal;

        panel.gameObject.SetActive(false);
    }
}
