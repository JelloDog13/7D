using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    #region Show In Inspector

    [Header("GUI")]
    [SerializeField] Color _guizmoColor;

    [Header("RayTracing")]
    [SerializeField] float _checkDistance;
    [SerializeField] LayerMask _isItAnInteractableObject;
    [SerializeField] Transform _rayStartPos;
    [SerializeField] public RaycastHit[] _hitBuffer = new RaycastHit[1];
    public Collectible _targetObject;

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = _guizmoColor;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * _checkDistance;
        Gizmos.DrawRay(_rayStartPos.position, direction);
    }

    public bool ItemCheck()
    {
        int rayHitCount = Physics.RaycastNonAlloc(_rayStartPos.position, transform.TransformDirection(Vector3.forward), _hitBuffer, _checkDistance, _isItAnInteractableObject);
        
        return rayHitCount > 0;
    }

    public string RaycastTag()
    {
        for (int i = 0; i < _hitBuffer.Length; i++)
        { 
            _hitBuffer[i].transform.TryGetComponent<Collectible>(out _targetObject);
            return _hitBuffer[i].transform.tag;
        }
        return null;
    }

}
