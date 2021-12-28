using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTarget : MonoBehaviour
{
    private Bee bee;

    public Bee Bee()
    {
        return bee;
    }

    public void TakeBee(Collider collider)
    {
        collider.transform.parent.GetComponent<Bee>().Target = gameObject;
        collider.transform.parent.GetComponent<Bee>().GetCurrentTarget(gameObject);
        bee = collider.transform.parent.GetComponent<Bee>();
    }
}
