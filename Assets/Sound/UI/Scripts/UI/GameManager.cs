using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _eventSystem;
    [SerializeField] GameObject _UIMusic;
    [SerializeField] GameObject _UISFX;
    private void Start()
    {
        DontDestroyOnLoad(_eventSystem);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_UIMusic);
    }
}
