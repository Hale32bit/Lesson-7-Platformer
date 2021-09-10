using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    private Collider2D _collider;

    public int Coins { get; private set; }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>() == null)
            return;

        CollectCoin(collision.gameObject);
    }

    private void CollectCoin(GameObject coin)
    {
        GameObject.Destroy(coin);
        Coins++;
    }
}
