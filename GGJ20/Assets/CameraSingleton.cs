using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : MonoBehaviour {
    public Camera cam;

    private static CameraSingleton _instance;

    public static CameraSingleton Instance {
        get {
            return _instance;
        }
}

    public static Camera GetCamera() {
        return Instance.cam;
    }

    private void Awake() {
        if (Instance == null) {
            _instance = this;
        }
    }

    public static Vector3 CameraPositionToScenario(float x, float y, float z) {
        RaycastHit hit;
        Ray ray = GetCamera().ScreenPointToRay(new Vector3(x, y, z));
        int layerMask = 0;
        layerMask = 1 << 8;
        if (Physics.Raycast(ray, out hit, layerMask)) {
            Vector3 pos = hit.point;
            return pos;
        }
        return Vector3.zero;
    }

    public static int GetPixelHeight() {
        return Instance.cam.pixelHeight;
    }

    public static int GetPixelWidth() {
        return Instance.cam.pixelWidth;
    }

}
