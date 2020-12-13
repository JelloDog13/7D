using UnityEngine;

public abstract class UIPreferencesManager : MonoBehaviour
{
    [SerializeField] protected string _settingName;

    public abstract void SavePref();
    public abstract void LoadPrefs();
}
