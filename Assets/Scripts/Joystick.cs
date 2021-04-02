using UnityEngine;

public class Joystick : MonoBehaviour
{
    public RectTransform center;
    public RectTransform knob;
    
    private Vector2 startPos;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public float force;


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2)
        {
            Touch touch = Input.GetTouch(0);
            
            knob.gameObject.SetActive(true);
            center.gameObject.SetActive(true);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    knob.position = startPos;
                    break;
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    force = Vector2.Distance(touch.position, startPos);
                    center.position = touch.position;
                    break;
                case TouchPhase.Ended:
                    direction = Vector2.zero;
                    force = 0;
                    knob.gameObject.SetActive(false);
                    center.gameObject.SetActive(false);
                    break;
            }
        }

        direction.Normalize();
    }
}