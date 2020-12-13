using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestZone : MonoBehaviour
{
    [SerializeField] int _questNumber;
    [SerializeField] PlayerProgress _player;
    [SerializeField] GameObject _targetObject;
    private bool _questDone;
    private bool _textAvailable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_player.HasItem(_questNumber) && !_questDone)
        {
            Debug.Log("Quest DONE !");
            _player.RemoveItem(_questNumber);
            if (_player.SanityLevel() != 3)
            {
                _targetObject.SetActive(true);
            }
            //SON DE QUETE ACCOMPLIE
        }
        else ShowQuestLine();
        Debug.Log("Get the item !");
    }

    private void ShowQuestLine()
    {
        if (_textAvailable)
        {
            StartCoroutine(TextCooldown());
            //TEXTE BADASS
        }
    }

    private IEnumerator TextCooldown()
    {
        _textAvailable = false;
        yield return new WaitForSeconds(5);
        _textAvailable = true;
    }

}
