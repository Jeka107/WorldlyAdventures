
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToRay(Camera camera,Vector2 position,LayerMask layerMask)
    {
        Ray ray;

        ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
