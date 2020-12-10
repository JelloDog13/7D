using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Interaction
{
    private void Update()
    {
        InteractWithObject("Flower");
        InteractWithObject("DogToy");
        InteractWithObject("Logs");
    }
}
