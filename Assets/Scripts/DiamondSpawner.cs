using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Vector3 lastDiamondPosition = new Vector3(0, 0, 100);

    public GameObject Diamond;

    private void Update()
    {
        if (player.transform.position.z > lastDiamondPosition.z - 100)
        {
            SpawnNewDiamond();
        }
    }

    private void SpawnNewDiamond()
    {
        int diamonsInRow = Random.Range(1, 11);

        for (int i = 0; i < diamonsInRow; i++)
        {
            Vector3 position;

            if (i == 0)
            {
                position = GetNewDiamondPosition(true);
            }
            else
            {
                position = GetNewDiamondPosition(false);
            }
            Instantiate(Diamond, position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        }

    }

    private Vector3 GetNewDiamondPosition(bool isFirst)
    {
        float positionX;
        float positionY;
        float positionZ;


        if (isFirst == true)
        {
            positionX = Random.Range(-1, 2);

            while (positionX == 0)
            {
                positionX = Random.Range(-1, 2);
            }

            positionY = Random.Range(4, 7);

            int distanceBetweenRows = Random.Range(30, 121);
            positionZ = lastDiamondPosition.z + distanceBetweenRows;
        }
        else
        {
            positionX = lastDiamondPosition.x;
            positionY = lastDiamondPosition.y;
            positionZ = lastDiamondPosition.z + 10;
        }

        Vector3 newDiamondPosition = new Vector3(positionX, positionY, positionZ);
        lastDiamondPosition = newDiamondPosition;

        return newDiamondPosition;
    }
}