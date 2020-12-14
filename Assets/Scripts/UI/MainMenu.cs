using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _cameraUI;

    void Start()
    {
        //on désactive le cursorLock
        Cursor.lockState = CursorLockMode.None;
    }

}
