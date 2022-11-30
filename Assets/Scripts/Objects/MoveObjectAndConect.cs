using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
public class MoveObjectAndConect : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 scanPos;
    [SerializeField]
    private Vector3 rotationPosition;
    private Rigidbody rb;

    [SerializeField]
    new Camera camera;

    public bool isPlaca;

    private GameObject cameraTable;
    public bool isConected;
    bool isDragging;

    float distanceFromDestiny;

    public Transform conector;
    [Range(0.1f,2.0f)]
    public float minimumDistanceConnector = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraTable = GameObject.FindWithTag("CameraTable");
    }

    void FixedUpdate()
    {
        scanPos = transform.position;

        if (!isDragging && !isConected)
        {
            distanceFromDestiny = Vector3.Distance(transform.root.position, conector.position);

            if (distanceFromDestiny < minimumDistanceConnector)
            {
                rb.isKinematic = true;
                rb.useGravity = true;
              
                transform.root.position = Vector3.MoveTowards(transform.root.position, conector.position, 0.02f);
                
               // transform.root.rotation = new Vector7(89.2972412f, 184.819687f, 270.947571f,10f);

            }
            if (distanceFromDestiny < 0.01f)
            {
                rb.isKinematic = false;
                rb.useGravity = false;
                isConected = true;
                rb.transform.rotation = Quaternion.Euler(rotationPosition);
                transform.root.position = conector.position;
            }

        }

    }
    void OnMouseDown()
    {
        if (cameraTable.activeSelf)
        {
            rb.useGravity = false;
            screenPoint = camera.WorldToScreenPoint(scanPos);
            offset = scanPos - camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            isConected = false;
            isDragging = true;

        }
    }
    void OnMouseDrag()
    {
        if (cameraTable.activeSelf)
        {
            rb.useGravity = false;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = camera.ScreenToWorldPoint(curScreenPoint) + offset;
            if(curPosition.y < 1.065432)
            {
                curPosition.y = 1.085432f;
            }
            transform.position = curPosition;

        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if (!isConected)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

        }
    }

}


/*
 
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
 */