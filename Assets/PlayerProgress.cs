using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField] QuestZone _jimmyInteractZone, _margueriteInteractZone, _dogInteractZone;
    [SerializeField] SanityManager _sanity;
    public List<Collectible> _itemsObtained;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int SanityLevel()
    {
        return _sanity._sanityLevel;
    }

    public void AddItem(Collectible newItem)
    {
        _itemsObtained.Add(newItem);
        _sanity.IncreaseSanity();
    }

    public void RemoveItem(int itemNumber)
    {
        for(int i = 0; i < _itemsObtained.Count ; i++ )
        {
            if(_itemsObtained[i]._questNumber == itemNumber)
            {
                _itemsObtained.Remove(_itemsObtained[i]);
                Debug.Log("item Removed");
            }
        }

    }

    public bool HasItem(int itemNumber)
    {
        foreach (Collectible item in _itemsObtained)
        {
            if (item._questNumber == itemNumber)
            {
                return true;
            }
            else return false;
        }
        return false;
    }
}
