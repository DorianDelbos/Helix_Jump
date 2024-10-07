using UnityEngine;

public class CameraHelix : MonoBehaviour
{
    [SerializeField] private Transform transformAttach;
    private Vector3 position = Vector3.zero;
    [SerializeField] private float offset = 1.0f;

    private void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        position.y = Mathf.Min(transformAttach.position.y + offset, position.y);
        transform.position = position;
    }
}
