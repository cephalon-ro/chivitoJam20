using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameProvider : MonoBehaviour {
    public List<string> satelliteNames;

    public string GetSatName() {
        if (satelliteNames == null || satelliteNames.Count < 1) {
            return "No name";
        }
        int rand = Random.Range(0,satelliteNames.Count - 1);
        string toReturn = satelliteNames[rand];
        satelliteNames.RemoveAt(rand);
        return toReturn;
    }
}
