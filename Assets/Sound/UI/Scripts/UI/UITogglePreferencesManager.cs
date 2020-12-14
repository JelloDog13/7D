using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class UITogglePreferencesManager : UIPreferencesManager
{
    [SerializeField] bool _defaultValue;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    public override void LoadPrefs()
    {
        if(PlayerPrefs.HasKey(_settingName))
        {
            int value = PlayerPrefs.GetInt(_settingName);
            Toggle.isOn = value != 0;
        }
        else
        {
            Toggle.isOn = _defaultValue;
        }
    }

    public override void SavePref()
    {
        PlayerPrefs.SetInt(_settingName, (Toggle.isOn) ? 1 : 0);
    }

    private Toggle _toggle;

    private Toggle Toggle
    {
        get
        {
            if (_toggle == null)
            {
                _toggle = GetComponent<Toggle>();
            }
            return _toggle;
        }
    }
}
