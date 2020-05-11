using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUnitButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        transform.root.GetComponent<ChoicePanel>().Increment();
    }
}
