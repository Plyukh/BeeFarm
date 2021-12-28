using UnityEngine;

public class Bee : MonoBehaviour
{
    private Animator animator;
    CoinCounter coinCounter;
    [SerializeField] protected float speed = 6f;
    protected float smooth = 3f;
    protected float radius = 2f;
    [SerializeField] private GameObject dust;
    [SerializeField] protected GameObject target;
    private GameObject currentTarget;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    public GameObject GetCurrentTarget(GameObject CurrentTarget)
    {
        return currentTarget = CurrentTarget;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coinCounter = GameObject.Find("Beehive").GetComponent<CoinCounter>();
    }

    private void Update()
    {
        Move();
        Pollination();
    }

    protected void Move()
    {
        if(currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget.transform.rotation, smooth);
        }
    }
    protected void Pollination()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Flowers"));
        foreach (var collider in hitColliders)
        {
            coinCounter.Coins(5);

            currentTarget = collider.gameObject;
            transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
            collider.transform.parent.GetComponent<Animator>().SetTrigger("Flower");

            animator.SetTrigger("Pollination");
            dust.SetActive(true);
        }
    }

    public void Pollination_Off()
    {
        GetCurrentTarget(target);
        dust.SetActive(false);
    }
}
