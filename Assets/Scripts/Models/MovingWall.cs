using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingWall : MonoBehaviour
{
    [SerializeField] private bool isHorizontal;
    [SerializeField] private ParticleSystem wallFrictionEffect;

    private Rigidbody2D rb;

    private delegate IEnumerator MovePlatformDirection();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void OnEnable()
    {
        EndGameManager.OnFallingWalls += MakeKinematic;
    }

    private void OnDisable()
    {
        EndGameManager.OnFallingWalls -= MakeKinematic;
    }

    public void StartMoving()
    {
        if (isHorizontal)
        {
            StartCoroutine(MovePlatform(MovePlatformHorizontalCoroutine));
        }
        else
        {
            StartCoroutine(MovePlatform(MovePlatformVerticalCoroutine));
        }
    }

    private IEnumerator MovePlatform(MovePlatformDirection movePlatformDirection)
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(movePlatformDirection());
        yield return new WaitForSeconds(1f);
        StartCoroutine(MovePlatform(movePlatformDirection));
    }

    private IEnumerator MovePlatformVerticalCoroutine()
    {
        wallFrictionEffect.Play();
        transform.DOMoveY(Random.Range(-3f, 3f), Random.Range(1f, 2f));
        yield return new WaitForSeconds(3f);
        transform.DOPause();
        wallFrictionEffect.Stop();
    }

    private IEnumerator MovePlatformHorizontalCoroutine()
    {
        wallFrictionEffect.Play();
        transform.DOMoveX(Random.Range(-4.5f, 4.5f), Random.Range(1f, 2f));
        yield return new WaitForSeconds(3f);
        transform.DOPause();
        wallFrictionEffect.Stop();
    }

    private void MakeKinematic()
    {
        StopAllCoroutines();
        rb.isKinematic = false;
    }
}
