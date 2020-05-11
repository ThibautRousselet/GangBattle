using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    public void SetRoofText(string text)
    {
        GetComponentInChildren<TextMeshPro>().text = text;
    }
}
