using TMPro;
using UnityEngine;

public class InteractableRay : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private TMP_Text interactMsg;
    [SerializeField, Min(0.5f)] private float rayDistance = 0.6f;

    private RaycastHit hit;

    private void Update()
    {
        RaycastCheckItems();
    }

    private void RaycastCheckItems()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
  
        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);
            interactMsg.enabled = true;

            if (Input.GetKeyUp(KeyCode.E))
            {
                if (hit.transform.TryGetComponent(out Interactable item))
                {
                    item.Interact();
                }
            }
        }

        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.yellow);
            interactMsg.enabled = false;
        }
    }
}