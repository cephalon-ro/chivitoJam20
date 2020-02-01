using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    Quaternion targetRotation;
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotatevel = 6;
    public float maxVel = 40;
    private float currentVel = 0;
    float forwardInput, turnInput;
    private Vector3 moveDir = Vector3.zero;
    CharacterController cBody;
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    // Start is called before the first frame update

    void Start()
    {
        if (GetComponent<CharacterController>())
            cBody = GetComponent<CharacterController>();

        else
            Debug.LogError("El personaje no tiene CharacterController");
        targetRotation = transform.rotation;
        forwardInput = turnInput = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Run();
        Turn();
    }
    void GetInput()
    {
        if (Input.GetAxis("Vertical") != 0)
            forwardInput = 1;
        turnInput = Input.GetAxis("Horizontal");
    }
    void Run()
    {
        // if (Mathf.Abs(forwardInput) > inputDelay)
        //  {
        //moverse tank controls
        moveDir = new Vector3(0, 0, forwardInput);
        moveDir = transform.TransformDirection(moveDir);
        moveDir.x *= forwardVel;
        moveDir.z *= forwardVel;
        //  }
    }
    void Turn()
    {
        transform.Rotate(0, turnInput * rotatevel, 0);
        cBody.Move(moveDir * Time.deltaTime);
    }
}
