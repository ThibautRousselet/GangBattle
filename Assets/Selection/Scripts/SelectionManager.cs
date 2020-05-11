using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private bool isEnabled = true;

    public void Enable()
    {
        isEnabled = true;
    }
    public void Disable()
    {
        if (Main.Instance.overedNH != null && Main.Instance.phase == GamePhase.Normal)
            Main.Instance.overedNH.OnLeaveOver();
        isEnabled = false;
    }

    private void ButtonHandling(InGameButton button)
    {
        if (Input.GetMouseButtonDown(0))
        {
            button.Onclick();
        }
        else
        {
            button.OnOver();
        }
    }

    private void NeighborhoodHandling(Neighborhood nh)
    {
        //Click on NH
        if (Input.GetMouseButtonDown(0))
        {
            //Click on NH
            if (Main.Instance.selectedNH != null)
            {
                Main.Instance.selectedNH.Interact(nh);
            }
            else
            {
                nh.Onclick();
            }
        }
        //Mouse over NH
        else if (Main.Instance.selectedNH != null)
        {
            nh.OnOver();
            Main.Instance.selectedNH.previewInteract(nh);
        }
        else
        {
            nh.OnOver();
        }
    }

    private void VoidHandling()//When no relevant element is pointed
    {
        if (Input.GetMouseButtonDown(0) && Main.Instance.phase == GamePhase.Normal)
            Neighborhood.UnSelect();
        else
        {
            if (Main.Instance.overedNH != null && Main.Instance.phase == GamePhase.Normal)
                Main.Instance.overedNH.OnLeaveOver();
            if (Main.Instance.overedButton != null)
                Main.Instance.overedButton.OnLeaveOver();
        }
    }
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && isEnabled) //If ray hits and there is no GUI element overed
        {
            var nh = hit.transform.GetComponentInParent<Neighborhood>();
            var button = hit.transform.GetComponentInParent<InGameButton>();
            
            if (button != null)
            {
                ButtonHandling(button);
            }
            else if (nh != null && Main.Instance.phase == GamePhase.Normal)
            {
                NeighborhoodHandling(nh);
            }
            else
            {
                VoidHandling();
            }
        }
    }
}
