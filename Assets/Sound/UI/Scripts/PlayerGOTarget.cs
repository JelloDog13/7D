using UnityEngine;

public class PlayerGOTarget : MonoBehaviour
{
    [SerializeField] GameObjectVariable _playerGameObject;

    void Start()
    {
        if(gameObject == null)
        {
            gameObject.GetComponent<GameObject>();
        }
        
        _playerGameObject.value = gameObject;
    }
}
