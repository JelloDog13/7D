using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class UIToggleGroupPreferencesManager : UIPreferencesManager
{
    [SerializeField] Toggle _defaultSelected;

    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
    }

    public override void LoadPrefs()
    {
        ToggleGroup.SetAllTogglesOff();
        Toggle[] toggles = ToggleGroup.GetComponentsInChildren<Toggle>();

        if(PlayerPrefs.HasKey(_settingName))
        {
            int index = PlayerPrefs.GetInt(_settingName);
            toggles[index].isOn = true;
        }
        else
        {
            foreach (Toggle toggle in toggles)
            {
                if(toggle == _defaultSelected)
                {
                    toggle.isOn = true;
                    break;
                }
            }
        }
    }

    public override void SavePref()
    {
        int index = 0;
        Toggle[] toggles = ToggleGroup.GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                PlayerPrefs.SetInt(_settingName, index);
                break;
            }
        }
    }

    private ToggleGroup _toggleGroup;

    private ToggleGroup ToggleGroup
    {
        get
        {
            if (_toggleGroup == null)
            {
                _toggleGroup = GetComponent<ToggleGroup>();
            }
            return _toggleGroup;
        }
    }
}
