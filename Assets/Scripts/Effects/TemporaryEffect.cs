using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private void Start()
    {
        StartCoroutine(EffectDestroyingCoroutine());
    }

    private IEnumerator EffectDestroyingCoroutine()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
