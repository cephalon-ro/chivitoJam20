using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCamera : MonoBehaviour
{
    public Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward,
    m_camera.transform.rotation * Vector3.up);
    }
}
