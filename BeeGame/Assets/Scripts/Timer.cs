using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] MainBee mainBee;

    private Image timeBar;

    private float timer;
    private float time;
    private bool start;

    public float GetTimer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }
    public float GetTime
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }

    public Image TimeBar()
    {
        return timeBar;
    }

    public bool StartTimer(bool Start)
    {
        return start = Start;
    }

    private void Awake()
    {
        timeBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (start)
        {
            if (time > 0f)
            {
                time -= Time.deltaTime;
                timeBar.fillAmount = Mathf.Lerp(timeBar.fillAmount, time / timer, timer);
            }
            else
            {
                mainBee.Speed = mainBee.Speed / 2;
                mainBee.Target.GetComponent<BeeController>().Speed = mainBee.Target.GetComponent<BeeController>().Speed / 2;
                start = false;
            }
        }
    }
}