using UnityEngine;

public class Beehive : MonoBehaviour
{
    [SerializeField] private GameObject beehiveCanvas;
    private CoinCounter coinCounter;

    private void Awake()
    {
        coinCounter = GetComponent<CoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainBee")
        {
            beehiveCanvas.SetActive(true);
            coinCounter.BeehiveCoins(coinCounter.Coins());
            coinCounter.Coins(-coinCounter.Coins());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainBee")
        {
            beehiveCanvas.SetActive(false);
        }
    }
}
