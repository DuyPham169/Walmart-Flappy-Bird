using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    [SerializeField] private float initialMovespeed = 5f;
    [SerializeField] private float destroyTime = 5f;

    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (!GameManager.instance.gameActive)
            GetComponent<PipeBehavior>().enabled = false;

        DestroyPipeAfterTime();
        PipeMovement();
    }

    private void DestroyPipeAfterTime()
    {
        if ((Time.time - startTime) > destroyTime)
            Destroy(gameObject);
    }

    private void PipeMovement()
    {
        transform.Translate(Vector2.left * initialMovespeed * Time.deltaTime);
    }
}
