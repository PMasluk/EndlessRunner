using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float changeWayDistance;

    private float startPositionY;

    private void Start()
    {
        startPositionY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        ChangeWay();
        Jump();
        moveSpeed += 0.1f * Time.deltaTime;
    }

    private void ChangeWay()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < changeWayDistance)
        {
            transform.position = new Vector3(transform.position.x + changeWayDistance, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -changeWayDistance)
        {
            transform.position = new Vector3(transform.position.x - changeWayDistance, transform.position.y, transform.position.z);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < startPositionY + changeWayDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + changeWayDistance, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > startPositionY - changeWayDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - changeWayDistance, transform.position.z);
        }
    }

    private IEnumerator SmoothMove(Vector3 startPosition, Vector3 targetPosition)
    {
        float t = 0;

        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            t += Time.deltaTime;
            yield return null;
        }
    }
}