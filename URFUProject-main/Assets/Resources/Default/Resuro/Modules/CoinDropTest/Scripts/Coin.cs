using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Coin : MonoBehaviour
{
    private readonly int TakeTrigger = Animator.StringToHash("Take");

    [SerializeField] private Animator _animator;
    public Text CountCoin;

    public void Take()
    {
        Invoke("AddingCountCoins", 0.5f);
        _animator.SetTrigger(TakeTrigger);
        Destroy(gameObject, 0.5f);
    }

    public void Update()
    {
        transform.Rotate(0.0f, 0.1f, 0.0f);
    }

    private void AddingCountCoins()
    {
        CountCoin.text = Convert.ToString(Convert.ToInt32(CountCoin.text) + 1);
    }
}