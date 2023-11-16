using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ThugSystem : MonoBehaviour
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
        MoveToRedFlag();
    }

    private void MoveToRedFlag()
    {
        GameObject targetObject = GameObject.FindWithTag("RedFlag");
        
        if (targetObject != null)
        {
            _animator.SetBool("isMove", true);

            Vector3 velocity = _navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
       
            _animator.SetFloat("moveX", localVelocity.x);
            _animator.SetFloat("moveY", localVelocity.y);
            
            _navMeshAgent.SetDestination(targetObject.transform.position);
            
            
        }
        else
        {
            Debug.LogWarning("No Move");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedFlag"))
        {
            BYPoolManager.Instance.ReturnThugToPool(gameObject);
        }
    }
}
