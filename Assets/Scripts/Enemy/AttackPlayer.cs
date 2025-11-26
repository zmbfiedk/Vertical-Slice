using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] EnemyDetection _enemyDetection;
    [SerializeField] EnemyAI _enemyAI;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Attack();
    }

    private void Attack()
    {
        float dist = Vector3.Distance(_enemyDetection._player.position, transform.position);
        if (time >= 1f && dist <= _enemyAI._attackRange) 
        {
            Debug.Log("Attack Player");

            time = 0f;
        }   
    }
}
