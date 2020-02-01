using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(-10, 8.5f, -10);

    Vector3 destination = Vector3.zero;
    Controller charController;

    private void Start()
    {
        SetCameraTarget(target);
    }

    void SetCameraTarget(Transform t)
    {
        target = t;
        if (target != null)
        {
            if (target.GetComponent<Controller>())
            {
                charController = target.GetComponent<Controller>();
            }
            else
                Debug.LogError("El target necesita un CharacterController");
        }
        else
            Debug.Log("La camara necesita un target");
    }

    private void LateUpdate()
    {
        MoveToTarget();   
    }
    void MoveToTarget()
    {
        destination = offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }
    void LookAtTarget()
    {

    }
}
