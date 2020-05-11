using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private TextMeshPro InfoScreen;

    public List<ChoicePanel> listPanels;
    public HeadQuarter hq;
    public int TotalCost;
    public void RefreshDisplay()
    {
        InfoScreen.text = (Main.Instance.CurrentPlayer.Credits - TotalCost).ToString() + "CR";
    }

    public void UpdateCost()
    {
        TotalCost = 0;
        foreach(ChoicePanel pan in listPanels)
        {
            TotalCost += pan.cost * pan.value;
        }
        foreach (ChoicePanel pan in listPanels)
        {
            pan.minValue = 0;
            pan.maxValue = pan.value+(Main.Instance.CurrentPlayer.Credits - TotalCost) / pan.cost;
        }
        RefreshDisplay();
    }
}
