using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float minAgleRotation;
    [SerializeField]
    private float maxAngleRotation;

    private float angle;

    private void Start()
    {
        angle = Random.Range(minAgleRotation, maxAngleRotation);
    }

    private void Update()
    {
        transform.Rotate(0, 0, angle * Time.deltaTime);
    }

}
