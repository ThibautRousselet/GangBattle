using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodHandler : MonoBehaviour
{
    public List<Neighborhood> neighborhoods;

    void Start()
    {
        GetComponentsInChildren(neighborhoods);
        neighborhoods = new List<Neighborhood>(GetComponentsInChildren<Neighborhood>());
    }



    public void GenerateIncome(Player player)
    {
        Debug.Log("Start : " + player.Credits);
        foreach (Neighborhood nh in neighborhoods)
        {
            if (nh.Owner == player)
            {
                player.Credits += nh.CreditProduction;
            }
        }
        Debug.Log("End : " + player.Credits);
    }
}
