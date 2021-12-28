using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddBee : MonoBehaviour
{
    private CoinCounter coinCounter;
    [SerializeField] private GameObject beePrefab;
    [SerializeField] private MainBee mainBee;

    private void Awake()
    {
        coinCounter = GameObject.Find("Beehive").GetComponent<CoinCounter>();
    }

    public void AddBee()
    {
        if (mainBee.BeeCounter().Counter() < 10)
        {
            if (coinCounter.BeehiveCoins() >= 10)
            {
                coinCounter.BeehiveCoins(-10);
                Instantiate(beePrefab, mainBee.transform.position, mainBee.transform.rotation);
            }
        }
    }
}
