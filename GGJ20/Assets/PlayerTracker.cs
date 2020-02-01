using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform player;
    public float P1CanvasX = 0;
    public float P1CanvasY = 0;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = CameraSingleton.GetCamera().WorldToScreenPoint(player.position);
        P1CanvasX = pos.x;
        P1CanvasY = pos.z;
    }
}
