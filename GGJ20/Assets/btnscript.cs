using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnscript : MonoBehaviour
{
    private Button botonazo;

    // Start is called before the first frame update
    void Start()
    {
        botonazo = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Msg()
    {
        Debug.Log("aiuda");
    }
}
