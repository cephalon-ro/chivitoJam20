using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float mouseX;
    public float mouseY;
    public float mouseZ;
    public bool mouseClick;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        mouseZ = Input.mousePosition.z;
        Input.GetKey(KeyCode.Mouse0);
    }


    public void StartScene() {
        Debug.Log("clickeado");
        //SceneManager.LoadScene("SampleScene");
    }

    public void CreditsScene() {
        SceneManager.LoadScene("Credits");
    }

    public void ExitUnity() {
        Application.Quit();
    }
}
