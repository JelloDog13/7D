using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] HandgunScriptVariable _handgunScriptVariable;

    [Header("Menu")]
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] Toggle _playToggle;

    [Header("Button & Cursor")]
    [SerializeField] Texture2D _cursor;

    [Header("Audio")]
    [SerializeField] AudioSource _sfxPlayer;
    [SerializeField] AudioClip _clickClip;

    [Header("Exit")]
    [SerializeField] float _exitApplicationDelay;

    [Header("GameObject")]
    [SerializeField] GameObjectVariable _cameraMain;
    [SerializeField] GameObjectVariable _GunCamera;
    [SerializeField] GameObjectVariable _playerGameObjectVariable;

    [SerializeField] GameObject _panelSettings;
    [SerializeField] GameObject _panelControls;
    [SerializeField] GameObject _panelCredits;

    private void Awake()
    {
        //on active le cursorLock
        Cursor.lockState = CursorLockMode.Locked;

        if(_GunCamera.value != null)
        {
            _GunCamera.value.GetComponent<AudioListener>().enabled = false;
        }
    }

    private void Start()
    {
        var setters = Resources.FindObjectsOfTypeAll<UIPreferencesManager>();
        //charge les preferences
        foreach(var setter in setters)
        {
            setter.LoadPrefs();
        }

        var toggles = Resources.FindObjectsOfTypeAll<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    _sfxPlayer.PlayOneShot(_clickClip);
                }
            });
        }
    }

    private void Update()
    {
        //si on appuye sur ECHAP ou START alors on ative le cursor et timeScale = 0
        if(Input.GetButton("PauseMenu"))
        {
            Cursor.lockState = CursorLockMode.None;
            _handgunScriptVariable.value.enabled = false;
            _pauseMenu.SetActive(true);
            _playToggle.SetIsOnWithoutNotify(true);
            _playToggle.Select();
            _isActived = true;
        }
            
        

        else if (Input.GetButtonDown("PauseMenu") && _isActived)
        {
            //on déactive le tire
            _handgunScriptVariable.value.enabled = true;

            //on désactive le menu principal et on passe sur la MainCamera
            _pauseMenu.SetActive(false);

            //Debug.Log("main cam : " + _cameraMain.value);

            //on active le cursorLock
           Cursor.lockState = CursorLockMode.Locked;
            _isActived = false;
        }

        if (_pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if(_panelSettings.activeSelf)
        {
            _panelControls.SetActive(false);
            _panelCredits.SetActive(false);
        }
        if (_panelControls.activeSelf)
        {
            _panelSettings.SetActive(false);
            _panelCredits.SetActive(false);
        }
        if (_panelCredits.activeSelf)
        {
            _panelControls.SetActive(false);
            _panelSettings.SetActive(false);
        }

    }

    public void ExitApplication()
    {
        StartCoroutine(ExitApplicationCoroutine());
    }

    private IEnumerator ExitApplicationCoroutine()
    {
        yield return new WaitForSeconds(_exitApplicationDelay);

        Debug.Log("Quit Game");
        Application.Quit();
    }
}
