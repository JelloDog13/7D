using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestItemInteraction : Interaction
{
    [SerializeField] TMP_Text _pickUpItemText;
    private void InteractWithQuestObject(string tag)
    {
        base.InteractWithObject(tag);
        _pickUpItemText.text = "Press V to pick up" + " " + "the" + " " + tag;
    }

    private void Update()
    {
        InteractWithQuestObject("Flower");
        InteractWithQuestObject("DogToy");
        InteractWithQuestObject("Logs");
    }
}
