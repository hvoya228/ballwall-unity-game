using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private ParticleSystem frictionEffect;
    [SerializeField] private ParticleSystem deathEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        frictionEffect.Play();
    }

    public void Spawn()
    {
        Instantiate(gameObject, new Vector3(0, 4, 0), Quaternion.identity);
    }

    public void DeathAndRespawn()
    {
        Instantiate(gameObject, new Vector3(0, 4, 0), Quaternion.identity);
        Death();
    }

    public static void DeathAll()
    {
        var balls = FindObjectsOfType<Ball>();

        foreach (var ball in balls)
        {
            ball.Death();
        }
    }

    private void Death()
    {
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        gameObject.transform.DOScale(Vector3.zero, 0.5f);
        Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
