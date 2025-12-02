using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] EnemyDetection _enemyDetection;
    [SerializeField] EnemyAI _enemyAI;
    public float _attackCooldown = 0f;
    private float _dashDistance = 6f;
    private float _dashSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _attackCooldown += Time.deltaTime;
        Attack();
    }
    
    private void Attack()
    {
        float dist = Vector3.Distance(_enemyDetection._player.position, transform.position);
        if (_attackCooldown >= 1.5f && dist <= _enemyAI._attackRange) 
        {
            Vector3 direction = _enemyDetection._player.position - transform.position;
            Vector3 startPos = transform.position;
            Vector3 targetPos = startPos + direction.normalized * _dashDistance;
            
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _dashSpeed);
            _attackCooldown = 0f;
        }   
    }
}
