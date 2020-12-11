using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class UISliderVolumeSetter : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] string _exposedParameter;
    [SerializeField] AnimationCurve _volumeCurve;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeVolume()
    {
        float value = _volumeCurve.Evaluate(Slider.value);
        _mixer.SetFloat(_exposedParameter, value);
    }

    private Slider _slider;

    private Slider Slider
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
