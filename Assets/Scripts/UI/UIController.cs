﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _subMenu;
    [SerializeField] Toggle _playToggle;
    [SerializeField] Button _continueButton;
    [SerializeField] Texture2D _cursor;
    [SerializeField] AudioSource _sfxPlayer;
    [SerializeField] AudioClip _clickClip;
    [SerializeField] float _exitApplicationDelay;

    [Header("Panel")]
    [SerializeField] GameObject _panelSettings;
    [SerializeField] GameObject _panelControls;
    [SerializeField] GameObject _panelCredits;

    private void Awake()
    {
        Cursor.SetCursor(_cursor, new Vector2(0, 1), CursorMode.Auto);
    }

    private void Start()
    {
        var setters = Resources.FindObjectsOfTypeAll<UIPreferencesManager>();
        foreach(var setter in setters)
        {
            setter.LoadPrefs();
        }

        _playToggle.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
            {
                _continueButton.Select();
            }
        });

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
        if(Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                _subMenu.SetActive(false);
                _playToggle.SetIsOnWithoutNotify(false);
                _playToggle.Select();
            }
        }
    }

    public void ExitApplication()
    {
        StartCoroutine(ExitApplicationCoroutine());
    }

    private void GraphicsSettings()
    {
        // https://docs.unity3d.com/Manual/class-QualitySettings.html

        string[] names = QualitySettings.names;
        Debug.Log(names[QualitySettings.GetQualityLevel()]);
        QualitySettings.SetQualityLevel(0, true); // => true = redémarrer


        QualitySettings.antiAliasing = 1;
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        QualitySettings.masterTextureLimit = 1;
        QualitySettings.pixelLightCount = 1;
        QualitySettings.vSyncCount = 0;
        QualitySettings.shadowDistance = 40;
    }
    private void ControlSettings()
    {
        // Remapping des touches

        // Ne pas utiliser l'Input Manager et en coder un custom

        // - Définir les actions possibles dans le jeu
        // - Mapper une action avec un KeyCode
        // - Dans un script, tester Input.GetKey(KeyCode) pour chaque action
        // - Faire l'UI pour modifier le KeyCode pour chaque action

        // Sensibilité de la souris

        // Avoir une valeur de sensibilité x et y entre 0 et 1
        float xSensitivity = .5f;
        float ySensitivity = .5f;

        // Calculer le delta entre la position actuelle de la souris et la nouvelle position
        Vector2 delta = (Vector2)Input.mousePosition - _lastMousePosition;

        // Faire le Dot product avec l'axe x et y pour obtenir la vitesse du mouvement sur x et y
        float xSpeed = Vector2.Dot(delta, Vector2.right);
        float ySpeed = Vector2.Dot(delta, Vector2.up);

        // Multiplier par la sensitivité x / y
        xSpeed *= xSensitivity;
        ySpeed *= ySensitivity;

        // On peut utiliser cette vitesse pour bouger la caméra par exemple

        _lastMousePosition = Input.mousePosition;
    }

    

    public void OnClicSettings()
    {
        //si on clique gauche sourie ou bouton A de la manette
        if(Input.GetMouseButtonDown(0))
        {
            _panelSettings.SetActive(true);
            _panelControls.SetActive(false);
            _panelCredits.SetActive(false);
        }
    }

    public void OnClicControls()
    {
        //si on clique gauche sourie ou bouton A de la manette
        if (Input.GetMouseButtonDown(0))
        {
            _panelSettings.SetActive(false);
            _panelControls.SetActive(true);
            _panelCredits.SetActive(false);
        }
    }

    public void OnClicCredits()
    {
        //si on clique gauche sourie ou bouton A de la manette
        if (Input.GetMouseButtonDown(0))
        {
            _panelSettings.SetActive(false);
            _panelControls.SetActive(false);
            _panelCredits.SetActive(true);
        }
    }

    private GameObject _lastSelected;
    private Vector2 _lastMousePosition;

    private IEnumerator ExitApplicationCoroutine()
    {
        yield return new WaitForSeconds(_exitApplicationDelay);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
