using UnityEngine;

public class BodyCameraPhysicalOnOff : MonoBehaviour
{
    private Camera bodyCamera;

    private void Awake()
    {
        bodyCamera = GetComponent<Camera>();
        bodyCamera.enabled = false;
    }

    void Start()
    {
        bodyCamera.enabled = true;
    }
}