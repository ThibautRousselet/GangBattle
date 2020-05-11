using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class HeadQuarter : Neighborhood
{
    public ShopPanel Shop;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        Shop.gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        Main.Instance.NHHandler.GenerateIncome(Owner);
        Shop.UpdateCost();
        Main.Instance.phase = GamePhase.Shop;
        Main.Instance.ActionsLeft = 3;
        Main.Instance.camera.MoveTo(transform.position);
        Shop.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
