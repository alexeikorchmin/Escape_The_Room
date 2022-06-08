using UnityEngine;

public class BodyCameraPhysicalOnOff : MonoBehaviour
{
    private Camera bodyCamera;

    private void Awake()
    {
        bodyCamera = GetComponent<Camera>();
        bodyCamera.enabled = false;
    }

    private void Start()
    {
        bodyCamera.enabled = true;
    }
}