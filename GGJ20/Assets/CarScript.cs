using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        currentRandom = startRandom;
        StartCoroutine(CarRandomScript());
    }

    float startRandom = 0.05f;
    float currentRandom;
    float randomMult = 2f;


    private IEnumerator CarRandomScript() {
        bool canExit = false;
        float rand;
        while (!canExit) {
            yield return new WaitForSeconds(10f);
            rand = Random.value;
            if (rand < currentRandom) {
                StartCar();
                canExit = true;
            } else {
                currentRandom = currentRandom * randomMult;
            }
        }
    }



    void StartCar() {
        StartCoroutine(RunCar());
        StartCoroutine(CarDestroyer());
    }

    IEnumerator RunCar() {
        while (true) {
            yield return null;
            transform.Translate(Vector3.forward * Time.deltaTime * 65f);
        }
    }


    IEnumerator CarDestroyer() {
        while (transform.position.x > -150f) {
            yield return null;
        }
        GameObject.Destroy(gameObject);
    }

}
