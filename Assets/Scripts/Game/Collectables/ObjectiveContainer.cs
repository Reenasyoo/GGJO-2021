using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveContainer : MonoBehaviour
{

    [SerializeField] private List<GameObject> objectivePlaceholders = new List<GameObject>();
    [SerializeField] private GameObject objectiveBase = null;
    
    
    private void Awake()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PopulateObjectives()
    {
        var transform = objectiveBase.transform;
        var childs = transform.childCount;
        
        for (int i = 0; i < childs; i++)
        {
            objectivePlaceholders.Add(transform.GetChild(i).gameObject);
        }
    }
}
