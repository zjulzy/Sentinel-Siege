using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPanel : MonoBehaviour,IPointerClickHandler
{
    public void DeactiveAll()
    {
        foreach (var b in GetComponentsInChildren<TurrentItem>())
        {
            b.Deactivate();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        DeactiveAll();
    }
}
