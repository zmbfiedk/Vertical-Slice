using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] EnemyDetection _enemyDetection;
    private float _moveSpeed = 1f;
    private float _attackRange = 1.5f;  
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        time += time*Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
 
    private void MoveEnemy()
    {
        float dist = Vector3.Distance(_enemyDetection._player.position, transform.position);
        if (dist <= _enemyDetection._targetingRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, _enemyDetection._player.position, _moveSpeed * Time.deltaTime);
        }
        if (dist <= _attackRange)
        {
            Debug.Log("Within Attack Range");
            AttackPlayer();
        }
        else if (dist > _attackRange && dist <= _enemyDetection._targetingRange)
        {
            _moveSpeed = 1f;
        }   
    }
    private void AttackPlayer()
    {
        _moveSpeed = 0f;
        Debug.Log("Attack");
        if (time >=0.5)
        {
            Vector3 direction = (_enemyDetection._player.position - transform.position).normalized;
            Vector3 attackDirection = transform.position + direction;
            transform.position = Vector3.MoveTowards(transform.position, attackDirection, 3f * Time.deltaTime); 
            time = 0f;
        }
    }
}
