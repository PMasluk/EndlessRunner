using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 offsetPosition;

    private void Start()
    {
        offsetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(0, 0, player.position.z) + offsetPosition;
    }

}
