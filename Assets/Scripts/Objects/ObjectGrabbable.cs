using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{

    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTransfrom;

    public void Grab(Transform ObjectGrabPointTransform)
    {
        this.objectGrabPointTransfrom = ObjectGrabPointTransform;
        objectRigidBody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransfrom = null;
        objectRigidBody.useGravity = true;
    }

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransfrom != null)
        {
            float learpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position,objectGrabPointTransfrom.position, Time.deltaTime * learpSpeed);
            objectRigidBody.MovePosition(newPosition);
        }
    }
}
