using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] ItemChecker _itemChecker;
    [SerializeField] TMP_Text _pickUpItemText;
    public virtual void InteractWithObject(string tag)
    {
        if (_itemChecker.ItemCheck() && _itemChecker._hitBuffer[0].collider.CompareTag(tag))
        {
            _pickUpItemText.text = "Press V to pick up" + " " + "the" + " " + tag;

            if (Input.GetKeyDown(KeyCode.V))
            {
                _playerRb.constraints = RigidbodyConstraints.FreezeAll;
                _itemChecker._hitBuffer[0].collider.gameObject.SetActive(false);
            }
        }
    }
}
