using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
   {





        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartScene() {
        //Debug.Log("clickeado");
        SceneManager.LoadScene("TransitionScene");
    }

    public void CreditsScene() {
        SceneManager.LoadScene("Credits");
    }

    public void ExitUnity() {
        Application.Quit();
    }
}
