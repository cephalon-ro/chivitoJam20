﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    static AudioManager _instance;

    public AudioSource audioSource;

    public static AudioManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }



}
