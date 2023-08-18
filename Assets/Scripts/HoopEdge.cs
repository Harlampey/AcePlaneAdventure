using UnityEngine;

public class HoopEdge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlaneMovement plane))
        {
            plane.Break();
        }
    }
}
