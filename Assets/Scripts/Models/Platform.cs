using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool isAi;
    [SerializeField] private KeyCode keyCodeRight;
    [SerializeField] private KeyCode keyCodeLeft;

    private float platformSpeed = 8f;

    private void Update()
    {
        if (isAi)
        {
            MovePlatformByAi();
        }
        else
        {
            MovePlatformByKeys();
        }
    }


    private void MovePlatformByKeys()
    {
        float moveInput = 0f;

        if (Input.GetKey(keyCodeLeft))
        {
            if (transform.position.x > -7.2f)
            {
                if (transform.position.x < 1.6f && transform.position.x > 0)
                {
                    return;
                }

                moveInput = -1f;
            }
        }
        else if (Input.GetKey(keyCodeRight))
        {
            if (transform.position.x < 7.2f)
            {
                if (transform.position.x > -1.6f && transform.position.x < 0)
                {
                    return;
                }
               
                moveInput = 1f;
            }
        }

        Vector3 newPosition = transform.position + new Vector3(moveInput, 0f) * platformSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void MovePlatformByAi()
    {

    }
}
