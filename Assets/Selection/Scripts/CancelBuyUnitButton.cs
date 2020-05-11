using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelBuyUnitButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        GetComponentInParent<ChoicePanel>().Decrement();
        GetComponentInParent<ShopPanel>().UpdateCost();
    }
}
