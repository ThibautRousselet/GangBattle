using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Neighborhood : ClickableElement
{
    public int NbTroops = 0;
    public int CreditProduction = 1;
    public Player Owner;

    private LineRenderer lr;
    [SerializeField] private GameObject AttackPanel;
    [SerializeField] private GameObject MovePanel;
    [SerializeField] private List<TextMeshPro> TroopInfoTexts;
    [SerializeField] private List<Neighborhood> Neighbors;


    protected void Start()
    {
        base.Start();
        UpdateDisplay();
        lr = GetComponent<LineRenderer>();
    }

    public override void OnOver()
    {
        if (Main.Instance.selectedNH != this)
        {
            base.OnOver();
            if (Main.Instance.overedNH != null && Main.Instance.overedNH != this)
                Main.Instance.overedNH.OnLeaveOver();
            Main.Instance.overedNH = this;
        }
    }

    public override void OnLeaveOver()
    {
        if (Main.Instance.selectedNH != this)
        {
            base.OnLeaveOver();
            if (Main.Instance.selectedNH != null)
                Main.Instance.selectedNH.ResetLineRenderer();
        }
        Main.Instance.overedNH = null;
    }

    public override void Onclick()
    {
        UnSelect();
        if(Main.Instance.CurrentPlayer == Owner)
        {
            Main.Instance.selectedNH = this;
            foreach (var obj in meshesToHighlight)
            {
                obj.material = clickMaterial;
            }
        }
    }
    public void Interact(Neighborhood other)
    {
        if (Owner == other.Owner)
        {
            StartMove(other);
        }
        else
        {
            StartAttack(other);
        }
    }

    public void previewInteract(Neighborhood other)
    {
        if (other.Owner == Owner)
        {

        }
        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, other.transform.position);
        }
    }

    private void ResetLineRenderer()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }

    public static void UnSelect()
    {
        if (Main.Instance.selectedNH != null)
        {
            foreach (var obj in Main.Instance.selectedNH.meshesToHighlight)
            {
                obj.material = Main.Instance.selectedNH.defaultMaterial;
            }
        }
        
        Main.Instance.selectedNH = null;
    }

    public void StartAttack(Neighborhood nh)
    {
        ChoicePanel panel = Instantiate(AttackPanel, (nh.transform.position+transform.position)/2 + new Vector3(0, 3, -1), Quaternion.identity).GetComponent<ChoicePanel>();
        panel.Source = this;
        panel.Target = nh;
        panel.maxValue = NbTroops - 1;
        panel.minValue = 0;
        panel.isAttacking = true;
        Main.Instance.phase = GamePhase.Selection;
    }

    public void StartMove(Neighborhood nh)
    {
        if (this != nh)
        {
            ChoicePanel panel = Instantiate(MovePanel, (nh.transform.position + transform.position) / 2 + new Vector3(0, 3, -1), Quaternion.identity).GetComponent<ChoicePanel>();
            panel.Source = this;
            panel.Target = nh;
            panel.maxValue = NbTroops - 1;
            panel.minValue = 0;
            Main.Instance.phase = GamePhase.Selection;
        }
    }

    public void Attack(Neighborhood nh, int nbAttack)
    {
        if (nbAttack > 0)
            Main.Instance.ConsumeAction();

        NbTroops -= nbAttack;
        nh.NbTroops -= nbAttack;
        int nbSurvivors = -nh.NbTroops;

        if (nh.NbTroops <= 0)
        {
            nh.NbTroops = 0;
            if (nbSurvivors > 0)
            {
                nh.Owner = Owner;
                nh.NbTroops = nbSurvivors;
            } else
            {
                nh.Owner = Main.Instance.players[0];
            }
        }
            
        this.UpdateDisplay();
        nh.UpdateDisplay();
    }

    public void Move(Neighborhood nh, int nbMove)
    {
        if (nbMove > 0)
            Main.Instance.ConsumeAction();

        NbTroops -= nbMove;
        nh.NbTroops += nbMove;

        this.UpdateDisplay();
        nh.UpdateDisplay();
    }

    public void SetOwner(Player player)
    {
        if (Owner != player)
        {
            Owner = player;
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        foreach (var obj in GetComponentsInChildren<LightColumn>())
        {
            obj.GetComponentInParent<MeshRenderer>().material = Owner.material;
        }
        SetText(NbTroops.ToString());
    }

    public void SetText(string text)
    {
        foreach (var obj in TroopInfoTexts)
        {
            obj.text = text;
        }
    }
}
