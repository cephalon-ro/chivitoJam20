using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotatevel = 6;

    Quaternion targetRotation;
    CharacterController cBody;
//    public Ball baller;
    float forwardInput, turnInput;
    public bool MouseAim;
    public bool fired;
    private Vector3 moveDir = Vector3.zero;
    public GameObject mate;
    public GameObject meleeCollider;
    GameObject meleeClone;
    GameObject mateclone;
    public Ray playerdir;
    public Animator playerAnim;
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
        //Physics.IgnoreCollision(mateclone.GetComponent<Collider>(), GetComponent<Collider>());
        //SpawnBall();
        playerAnim = GetComponent<Animator>();
        targetRotation = transform.rotation;
        forwardInput = turnInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        MouseAim = Input.GetMouseButton(1);
    }


    // Update is called once per frame
    void Update()
    {
        //moveDir.y -= gravity * Time.deltaTime;
        GetInput();

        //FUTBOL
        //if (Input.GetKeyDown(KeyCode.R))
        //    SpawnBall();
        if (forwardInput != 0)
            playerAnim.SetBool("isRunning", true);
        else
            playerAnim.SetBool("isRunning", false);

 //       if (Input.GetKeyDown(KeyCode.Q) && attackCD == 0)
 //         Meleele();
        switch (MouseAim){
            case true:  
                if (moveDir.x != 0 || moveDir.z != 0)
                Stop();
                Turn();
                if (Input.GetKeyDown(KeyCode.E))
                    FireMate();
                    
                break;
            case false:
                Run();
                Turn();
                break;
        }
    }

    private void FixedUpdate()
    {
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

    void Stop()
    {
        moveDir.x = 0;
        moveDir.z = 0;
    }

    void Turn()
    {
            transform.Rotate(0, turnInput * rotatevel, 0);
            cBody.Move(moveDir * Time.deltaTime);
    }

    void FireMate()
    {
        mateclone = Instantiate(mate, transform.position + (transform.forward * 2), transform.rotation);
        Debug.Log("mate localpos before: " + mateclone.transform.localPosition);
        mateclone.GetComponent<Rigidbody>().AddForce(transform.up * 200);
        mateclone.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    void Fire()
    {
        playerdir = new Ray(transform.position, transform.forward);
        Debug.Log("player dir: " + playerdir);
        fired = true;
        //baller.Launch();
        //    baller.transform.position = Vector3.MoveTowards(baller.transform.position, playerdir.direction, ballerVel * Time.deltaTime);
    }

    //void SpawnBall()
    //{
        
    //    baller = Instantiate(baller, transform.position, transform.rotation);
    //    baller.transform.parent = gameObject.transform;
    //}

    void Meleele()
    {
        playerAnim.Play("attack2");
        meleeClone = Instantiate(meleeCollider, transform.position + (transform.forward*4), transform.rotation);
        meleeClone.transform.Rotate(180, 0, 0);
        meleeClone.transform.parent = gameObject.transform;
        //attackCD = 0.3f;
    }
}
