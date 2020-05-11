using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : InGameButton
{
    public override void Onclick()
    {
        base.Onclick();
        ChoicePanel panel = transform.root.GetComponent<ChoicePanel>();
        if (panel != null)
        {
            panel.Source.UpdateDisplay();
            panel.Target.UpdateDisplay();
        }
        
        Main.Instance.phase = GamePhase.Normal;
        Destroy(transform.root.gameObject);
    }
}

