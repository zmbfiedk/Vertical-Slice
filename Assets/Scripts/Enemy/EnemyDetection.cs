using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float targetingRange = 3;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }
    public void FindTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, playerMask);
        if (hits.Length > 0 )
        {
            Debug.Log("Hit");
        }
    }
}
