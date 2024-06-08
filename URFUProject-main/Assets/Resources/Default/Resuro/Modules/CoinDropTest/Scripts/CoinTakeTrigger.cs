using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTakeTrigger : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private bool _isTaked = false;
    private bool _hasTaker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CoinTaker>())
        _hasTaker = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CoinTaker>())
        _hasTaker = false;
    }

    private void Update()
    {
        if (_isTaked)
            return;
        if (_hasTaker)
        {
            _coin.Take();
            _isTaked = true;
        }
    }
}
