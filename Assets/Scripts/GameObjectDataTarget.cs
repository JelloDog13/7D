using UnityEngine;

public class GameObjectDataTarget : MonoBehaviour
{
    [SerializeField] GameObjectVariable _gameObjectVariable;

    void Start()
    {
        if(gameObject == null)
        {
            gameObject.GetComponent<GameObject>();
        }
        
        _gameObjectVariable.value = gameObject;
    }
}
