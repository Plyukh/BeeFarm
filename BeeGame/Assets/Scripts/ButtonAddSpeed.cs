using UnityEngine;
using UnityEngine.UI;

public class ButtonAddSpeed : MonoBehaviour
{
    [SerializeField] private MainBee mainBee;
    [SerializeField] private Timer timer;

    public void AddSpeed()
    {
        if (timer.GetTime <= 0f)
        {
            timer.StartTimer(true);
            mainBee.Speed = mainBee.Speed * 2;
            mainBee.Target.GetComponent<BeeController>().Speed = mainBee.Target.GetComponent<BeeController>().Speed * 2;
        }
        timer.GetTimer = 30f;
        timer.GetTime = timer.GetTimer;
        timer.TimeBar().fillAmount = 1;
    }
}
