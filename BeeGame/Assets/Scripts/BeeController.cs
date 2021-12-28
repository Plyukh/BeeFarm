using UnityEngine;


public class BeeController : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject circle;
    private Vector3 cameraMainPosition;
    
    private float speed = 5;
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

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        cameraMainPosition = camera.transform.position;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }
    }
    private void LateUpdate()
    {
        camera.transform.position = gameObject.transform.position + cameraMainPosition;
        circle.transform.position = new Vector3(gameObject.transform.position.x, circle.transform.position.y, gameObject.transform.position.z);
    }
}
