using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
public class MoveObjectAndConect : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 scanPos;

    [SerializeField]
    new Camera camera;

    public bool isConected;
    bool isDragging;

    float distanceFromDestiny;

    public Transform conector;
    [Range(0.1f,2.0f)]
    public float minimumDistanceConnector = 0.5f;

    void Update()
    {
        scanPos = transform.position;

        if (!isDragging && !isConected)
        {
            distanceFromDestiny = Vector3.Distance(transform.root.position, conector.position);

            if (distanceFromDestiny < minimumDistanceConnector)
            {
                transform.root.position = Vector3.MoveTowards(transform.root.position, conector.position, 0.02f);

            }
            if (distanceFromDestiny < 0.01f)
            {
                isConected = true;
                transform.root.position = conector.position;
            }

        }

    }
    void OnMouseDown()
    {
        GameObject cameraTable = GameObject.FindWithTag("CameraTable");
        if (cameraTable.active)
        {
            screenPoint = camera.WorldToScreenPoint(scanPos);
            offset = scanPos - camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            isConected = false;
            isDragging = true;

        }
    }
    void OnMouseDrag()
    {
        GameObject cameraTable = GameObject.FindWithTag("CameraTable");
        if (cameraTable.active)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = camera.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

}