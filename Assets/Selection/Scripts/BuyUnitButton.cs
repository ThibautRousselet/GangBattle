using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnitButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        GetComponentInParent<ChoicePanel>().Increment();
        GetComponentInParent<ShopPanel>().UpdateCost();
    }
}
