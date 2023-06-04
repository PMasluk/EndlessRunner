using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private EnvironmentPart environmentPart;

    private int spawnAmount = 1;
    private Vector3 lastEnvironmentPosition = new Vector3 (0, 0, 0);
    private List<EnvironmentPart> parts = new List<EnvironmentPart>();

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnStartEnvironment();
        }
    }

    private void Update()
    {
        if (player.transform.position.z > 35 * (spawnAmount - 3) - 17.5)
        {
            EnvironmentPart part = parts.FirstOrDefault();
            parts.Remove(part);
            part.gameObject.SetActive(false);
            part.transform.position = GetNewEnvironmentPosition();
            parts.Add(part);
            part.gameObject.SetActive(true);
            spawnAmount++;
            part.OnInstantiated();
        }
    }

    private void SpawnStartEnvironment()
    {
        EnvironmentPart part = Instantiate(environmentPart, GetNewEnvironmentPosition(), Quaternion.identity);
        spawnAmount++;
        parts.Add(part);
        part.OnInstantiated();
    }

    private Vector3 GetNewEnvironmentPosition()
    {
        Vector3 newEnvironmentPosition = new Vector3(lastEnvironmentPosition.x, lastEnvironmentPosition.y, lastEnvironmentPosition.z + 35);
        lastEnvironmentPosition = newEnvironmentPosition;
        return newEnvironmentPosition;
    }

}
