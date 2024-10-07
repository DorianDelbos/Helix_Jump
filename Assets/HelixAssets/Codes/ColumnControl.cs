using UnityEngine;

public class ColumnControl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.y -= Input.mousePositionDelta.x * Time.timeScale;
            transform.eulerAngles = eulerAngles;
        }
    }
}
