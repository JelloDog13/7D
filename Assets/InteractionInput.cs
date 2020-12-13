using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInput : MonoBehaviour
{
    [SerializeField] QuestItemInteraction _interact;
    void Update()
    {
        if (_interact.CanInteract())
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _interact.InteractWithObject();
            }
        }
    }
}
