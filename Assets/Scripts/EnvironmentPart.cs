using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPart : MonoBehaviour
{
    [SerializeField]
    private List<QuatersSpawner> quaters = new List<QuatersSpawner>(); 

    public void OnInstantiated()
    {
        foreach (QuatersSpawner quater in quaters)
        {
            quater.OnInstantiated();
        }
    }
}
