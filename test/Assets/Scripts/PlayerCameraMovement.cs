using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

public class PlayerCameraMovement : MonoBehaviour
{
    public static GameObject Instance;
    
    [SerializeField]
    private float _mouseSensitivity = 100f; // Set a default sensitivity
    [SerializeField]
    private Transform _playerBody;
    
    private float _xRotation;

    private void Awake()
    {
        Instance = this.gameObject;
    }

    public void RotateCamera(float x, float y)
    {
        _xRotation -= y;
        _xRotation = Mathf.Clamp(_xRotation, -70f, 70f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * x);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved && touch.position.x > Screen.width / 2f && !IsPointerOverUI(touch))
                {
                    RotateCamera(touch.deltaPosition.x * _mouseSensitivity * Time.deltaTime / Screen.width,
                                 touch.deltaPosition.y * _mouseSensitivity * Time.deltaTime / Screen.height);
                }
            }
        }
        else
        {
            float x = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
            RotateCamera(x, y);
        }
    }

    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = touch.position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
