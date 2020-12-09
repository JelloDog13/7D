using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] Texture2D _cursor;

    [Header("Panel")]
    [SerializeField] GameObject _panelSettings;
    [SerializeField] GameObject _panelControls;
    [SerializeField] GameObject _panelCredits;

    private void Awake()
    {
        Cursor.SetCursor(_cursor, new Vector2(0, 1), CursorMode.Auto);
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
}
