using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDistance : MonoBehaviour
{
    // audio source of violin
    public AudioSource violin;

    // transform of newborn
    public Transform newborn;

    // tranform of life
    public Transform life;

    // Update is called once per frame
    void Update()
    {
        // if the distance between Death and newborn is less than or equal to 10
        if (Vector3.Distance(transform.position, newborn.position) <= 10)
        {
            // play violin
            violin.Play();
        }

        // Debug.Log(Vector3.Distance(transform.position, life.position));

        // if the distance between Death and Life is less than or equal to 10
        if (Vector3.Distance(transform.position, life.position) <= 10)
        {
            // play violin
            violin.Play();
        }
    }
}
