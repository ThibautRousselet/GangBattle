using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateMovementButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        Main.Instance.phase = GamePhase.Normal;
        ChoicePanel panel = transform.root.GetComponent<ChoicePanel>();
        panel.Source.Move(panel.Target, panel.value);
        Destroy(transform.root.gameObject);
    }
}
