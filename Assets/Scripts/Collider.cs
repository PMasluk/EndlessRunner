using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private MeshRenderer meshDiamond;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("LostLife"))
        {
            return;
        }

        AudioManager.Instance.PlayGetPointEffect();
        effect.Play();
        ScoreManager.Instance.AddPoint();
        meshDiamond.enabled = false;
        StartCoroutine(DestroyDiamondCoroutine());
    }

    private IEnumerator DestroyDiamondCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
