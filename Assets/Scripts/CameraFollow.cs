using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;

    private void LateUpdate()
    {
        transform.position = target.position + targetOffset;
    }
}
