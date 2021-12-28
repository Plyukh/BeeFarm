using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    [SerializeField] RectTransform joystick;
    [SerializeField] RectTransform rectTransform;
    private void Awake()
    {
        joystick = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out Vector2 localPoint);
        if (Input.GetMouseButtonDown(0))
        {
            joystick.GetComponent<RectTransform>().anchoredPosition = localPoint;
            joystick.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            joystick.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            joystick.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            joystick.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }
}
