using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] bool isWrench, isFlower, isUmbrella;

    #endregion

    #region Private

    private bool _canPickup = false;
    private Player _player;
    private Text _notification;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _notification = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        _notification.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canPickup)
        {
            // Remplis l'inventaire en fonction de l'item trouvé
            if (isWrench)
            {
                UIController.instance._wrenchImage.enabled = true;
                _player._hasWrench = true;
                _player._hasAnyItem = true;
            }

            if (isFlower)
            {
                UIController.instance._flowerImage.enabled = true;
                _player._hasFlower = true;
                _player._hasAnyItem = true;
            }

            if (isUmbrella)
            {
                UIController.instance._umbrellaImage.enabled = true;
                _player._hasUmbrella = true;
                _player._hasAnyItem = true;
            }

            Destroy(gameObject);
        }
    }

    #endregion

    #region Private methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.enabled = true;
            _canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.enabled = true;
            _canPickup = false;
        }
    }

    #endregion

}
