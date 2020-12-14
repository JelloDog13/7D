using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] _myRigidbodies;
    private Animator _anim;
    
    void Awake()
    {
        _myRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in _myRigidbodies)
        {
            rb.isKinematic = true;
        }
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void SetRagdoll()
    {
        foreach (Rigidbody rb in _myRigidbodies)
        {
            rb.isKinematic = false;
            _anim.enabled = false;
        }
    }
}
