using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoicePanel : MonoBehaviour
{
    [SerializeField] private TextMeshPro title;
    [SerializeField] private TextMeshPro NBDisplay;

    public Neighborhood Source;
    public Neighborhood Target;

    public int cost = 1; //Used in the shop

    public bool isAttacking = false;

    public int value = 0;
    public int minValue = 0;
    public int maxValue = 10;

    public void Increment()
    {
        if (value < maxValue)
            value++;
        Refresh();
    }

    public void Decrement()
    {
        if (value > minValue)
            value--;
        Refresh();
    }

    public void Reset()
    {
        value = 0;
        Refresh();
    }

    public void Refresh()
    {
        if (Source != null && Target != null)
        {
            Source.SetText((Source.NbTroops - value).ToString() + "(-" + value + ")");
            if (isAttacking)
                Target.SetText((Target.NbTroops - value).ToString() + "(-" + value + ")");
            else
                Target.SetText((Target.NbTroops + value).ToString() + "(+" + value + ")");
        }
        NBDisplay.text = value.ToString();
    }

    public int GetValue()
    {
        return value;
    }
}
