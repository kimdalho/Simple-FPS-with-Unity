using UnityEngine;

public class AimRigController : MonoBehaviour
{
    public Transform aimTarget;
    public Camera cam;
    public float distance = 10f;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            aimTarget.position = hit.point;
        }
        else
        {
            aimTarget.position = ray.GetPoint(distance);
        }
    }
}
