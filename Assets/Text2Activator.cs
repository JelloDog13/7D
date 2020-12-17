using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text2Activator : MonoBehaviour
{
    [SerializeField] TMP_Text _text2;

    public void ActiveText2()
    {
        _text2.gameObject.SetActive(true);
    }
}
