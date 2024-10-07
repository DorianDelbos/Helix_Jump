using UnityEngine;

public class ColumnControl : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.y -= Input.mousePositionDelta.x * Time.timeScale * sensitivity;
            transform.eulerAngles = eulerAngles;
        }
    }
}
