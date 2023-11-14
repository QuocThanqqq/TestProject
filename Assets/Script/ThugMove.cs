using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThugMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    
    
    private void Awake()
    {
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    void Update()
    {
        SetDestinationToRedFlag();
    }

    void SetDestinationToRedFlag()
    {
        GameObject targetObject = GameObject.FindWithTag("RedFlag");
        if (targetObject != null)
        {
            _animator.SetBool("isMove", true);
            Vector3 direction = targetObject.transform.position - transform.position;
            direction.Normalize();
            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);
            _navMeshAgent.SetDestination(targetObject.transform.position);
        }
        else
        {
            Debug.LogWarning("No Move");
        }
    }
}
