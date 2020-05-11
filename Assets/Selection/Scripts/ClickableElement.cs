using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableElement : MonoBehaviour
{
     public Material defaultMaterial;
     public Material overMaterial;
     public Material clickMaterial;
     public List<MeshRenderer> meshesToHighlight;

    protected void Start()
    {
        foreach (var obj in meshesToHighlight)
        {
            obj.material = defaultMaterial;
        }
    }

    public virtual void Onclick()
    {
        foreach (var obj in meshesToHighlight)
        {
            obj.material = clickMaterial;
        }
    }
    public virtual void OnOver()
    {
        foreach (var obj in meshesToHighlight)
        {
            obj.material = overMaterial;
        }
    }
    public virtual void OnLeaveOver()
    {
        foreach (var obj in meshesToHighlight)
        {
            obj.material = defaultMaterial;
        }
    }



}
