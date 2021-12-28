using UnityEngine;

public class MainBee : Bee
{
    [SerializeField] private BeeCounter beeCounter;
    [SerializeField] private GameObject beesTarget;
    private BeeTarget[] targets = new BeeTarget[9];

    public BeeCounter BeeCounter()
    {
        return beeCounter;
    }

    public BeeTarget[] Targets()
    {
        return targets;
    }

    private void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = beesTarget.transform.GetChild(i).GetComponent<BeeTarget>();
        }
    }

    private void Update()
    {
        AddBee();
        GetSpeed();
        TargetMoveToMainBee();
        Move();
        Pollination();
    }

    private void AddBee()
    {
        if(beeCounter.Counter() < 10)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Bees"));
            foreach (var collider in hitColliders)
            {
                foreach (var target in Targets())
                {
                    if (!target.Bee())
                    {
                        target.TakeBee(collider);
                        break;
                    }
                }
                collider.gameObject.SetActive(false);
            }
        }
    }

    private void TargetMoveToMainBee()
    {
        beesTarget.transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position, target.GetComponent<BeeController>().Speed * Time.deltaTime);
        beesTarget.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, target.transform.rotation, smooth);
    }

    private void GetSpeed()
    {
        foreach (var target in Targets())
        {
            if (target.Bee())
            {
                target.Bee().Speed = Speed;
            }
        }
    }
}
