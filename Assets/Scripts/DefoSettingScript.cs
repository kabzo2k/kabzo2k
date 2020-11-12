using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class DefoSettingScript : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
    }

}