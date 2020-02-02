using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public NewController player;
    public float P1CanvasX = 0;
    public float P1CanvasY = 0;
    private Vector3 pos;
    int screenHeight;
    int screenWidth;
    float warpHeight;
    float warpWidth;
    public float warpZeroHeight;
    public float warpZeroWidth;
    float warpOffsetMultiplier = 0.05f;
    
    void Start() {
        screenHeight = CameraSingleton.GetPixelHeight();
        screenWidth = CameraSingleton.GetPixelWidth();

        warpHeight = screenHeight + screenHeight * warpOffsetMultiplier;
        warpWidth = screenWidth + screenWidth * warpOffsetMultiplier;

        warpZeroHeight = 0 - screenHeight * warpOffsetMultiplier;
        warpZeroWidth = 0 - screenWidth * warpOffsetMultiplier;

    }
    

    void Update() {
        pos = CameraSingleton.GetCamera().WorldToScreenPoint(player.transform.position);
        if (pos.x > warpWidth) {
            Vector3 newPos = new Vector3(0f, pos.y, pos.z);
            Vector3 worldPos = CameraSingleton.CameraPositionToScenario(newPos);
            Debug.Log("Pos: " + worldPos);
            player.Teleport(new Vector3(worldPos.x, player.transform.position.y, worldPos.z));
        }
        if (pos.y > warpHeight) {
            Vector3 newPos = new Vector3(pos.x, 0f, pos.z);
            Vector3 worldPos = CameraSingleton.CameraPositionToScenario(newPos);
            Debug.Log("Pos: " + worldPos);
            player.Teleport(new Vector3(worldPos.x, player.transform.position.y, worldPos.z));
        }
        if (pos.x < warpZeroWidth) {
            Vector3 newPos = new Vector3(screenWidth, pos.y, pos.z);
            Vector3 worldPos = CameraSingleton.CameraPositionToScenario(newPos);
            Debug.Log("Pos: " + worldPos);
            player.Teleport(new Vector3(worldPos.x, player.transform.position.y, worldPos.z));
        }
        if (pos.y < warpZeroHeight) {
            Vector3 newPos = new Vector3(pos.x, screenHeight, pos.z);
            Vector3 worldPos = CameraSingleton.CameraPositionToScenario(newPos);
            Debug.Log("Pos: " + worldPos);
            player.Teleport(new Vector3(worldPos.x, player.transform.position.y, worldPos.z));
        }
        P1CanvasX = pos.x;
        P1CanvasY = pos.z;
    }
}
