using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RemoveUnitButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        transform.root.GetComponent<ChoicePanel>().Decrement();
    }
}
