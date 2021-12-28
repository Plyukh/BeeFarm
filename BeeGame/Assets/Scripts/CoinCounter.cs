using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textBeehiveCoins;
    private int coins;
    private int beehiveCoins;

    public int Coins()
    {
        return coins;
    }
    public int Coins(int Coins)
    {
        return coins += Coins;
    }

    public int BeehiveCoins()
    {
        return beehiveCoins;
    }
    public int BeehiveCoins(int Coins)
    {
        return beehiveCoins += Coins;
    }

    private void Update()
    {
        Counter();
    }

    private void Counter()
    {
        if(coins < 0)
        {
            coins = 0;
        }

        textCoins.text = coins.ToString();
        textBeehiveCoins.text = beehiveCoins.ToString();
    }
}
