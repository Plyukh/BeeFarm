using UnityEngine;
using UnityEngine.UI;

public class BeeCounter : MonoBehaviour
{
    [SerializeField] MainBee mainBee;
    [SerializeField] int counterBees;
    [SerializeField] int counterMainBee;
    private Text text;
    private int beeCounter;

    public int Counter()
    {
        return beeCounter;
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        Count();
    }

    void Count()
    {
        counterBees = 0;
        if (mainBee != null)
        {
            counterMainBee = 1;
        }
        else
        {
            counterMainBee = 0;
        }
        foreach (var target in mainBee.Targets())
        {
            if (target.Bee())
            {
                counterBees += 1;
            }
        }
        beeCounter = counterMainBee + counterBees;
        text.text = beeCounter.ToString();
    }
}
