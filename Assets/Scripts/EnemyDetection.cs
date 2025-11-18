using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float targetingRange = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.black;   
        Handles.DrawWireDisc(transform.position, Vector3.down, targetingRange);
    }
}
