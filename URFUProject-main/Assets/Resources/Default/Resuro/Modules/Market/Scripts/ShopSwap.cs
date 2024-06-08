using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwap : MonoBehaviour
{
    public static bool IsMainShop = true;
    public GameObject MainShop, SelectedShop;

    public void SwapShop()
    {
        IsMainShop = false;
        MainShop.SetActive(false);
        SelectedShop.SetActive(true);
    }
}
