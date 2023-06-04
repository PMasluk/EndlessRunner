using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LostLife : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> beeList = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Diamonds"))
        {
            return;
        }

        beeList.LastOrDefault().SetActive(false);
        beeList.Remove(beeList.LastOrDefault());
        AudioManager.Instance.PlayLostLifeEffect();

        if (beeList.Count == 0)
        {
            GamePlayManager.Instance.LostAllLifes();
        }
    }
}
