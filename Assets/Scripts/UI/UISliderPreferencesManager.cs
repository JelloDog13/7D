using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UISliderPreferencesManager : UIPreferencesManager
{
    [SerializeField] float _defaultValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void SavePref()
    {
        PlayerPrefs.SetFloat(_settingName, Slider.value);
    }

    public override void LoadPrefs()
    {
        Slider.value = PlayerPrefs.GetFloat(_settingName, _defaultValue);
    }

    Slider _slider;

    public Slider Slider
    {
        get
        {
            if (_slider == null)
            {
                _slider = GetComponent<Slider>();
            }
            return _slider;
        }
         
    }
}
