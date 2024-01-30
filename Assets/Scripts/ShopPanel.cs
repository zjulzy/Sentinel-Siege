using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public void DeactiveAll()
    {
        foreach (var b in GetComponentsInChildren<TurrentItem>())
        {
            b.Deactivate();
        }
    }
}
