using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestItemInteraction : Interaction
{
    [SerializeField] TMP_Text _pickUpItemText;
    [SerializeField] Animator _fade;
    private bool _isFading;

    private void ShowText()
    {
            _pickUpItemText.text = "Press V to pick up" + " " + "the" + " " + base._targetTag;
    }

    public void Fade()
    {
        _fade.Play("Fade");
    }


    private void Update()
    {
        if (base.CanInteract())
        {
            ShowText();
        }
        else _pickUpItemText.text = "";

        if (base._isInteracting)
        {
            Fade();
        }

    }
}
