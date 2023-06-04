using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuatersSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> configs = new List<GameObject>();

    private int index;

    public void OnInstantiated()
    {
        foreach (GameObject config in configs)
        {
            config.SetActive(false);
        }

        int randomIndex = Random.Range(0, configs.Count);

        while (randomIndex == index)
        {
            randomIndex = Random.Range(0, configs.Count);
        }

        configs[randomIndex].SetActive(true);
        index = randomIndex;
    }
}
