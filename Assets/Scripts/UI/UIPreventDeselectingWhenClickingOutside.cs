using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventSystem))]
public class UIPreventDeselectingWhenClickingOutside : MonoBehaviour
{

    private void Awake()
    {
        _eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (_eventSystem.currentSelectedGameObject != null)
        {
            _lastSelected = _eventSystem.currentSelectedGameObject;
        }
        else
        {
            _eventSystem.SetSelectedGameObject(_lastSelected);
        }
    }

    private EventSystem _eventSystem;
    private GameObject _lastSelected;
}
