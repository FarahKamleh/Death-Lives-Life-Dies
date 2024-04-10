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

    // use bools to ensure played once
    bool closeNewborn = false;
    bool closeLife = false;

    // Update is called once per frame
    void Update()
    {
        // if the distance between Death and newborn is less than 10 and 
        if (Vector3.Distance(transform.position, newborn.position) < 10)
        {
            if (closeNewborn == false)
            {
                // play violin
                violin.Play();

                // set to true
                closeNewborn = true;
            }
        }
        else
        {
            closeNewborn = false;
        }

        Debug.Log(Vector3.Distance(transform.position, life.position));

        // if the distance between Death and Life is less than 10
        if (Vector3.Distance(transform.position, life.position) < 10)
        {
            if (closeLife == false)
            {
                // play violin
                violin.Play();

                // set to true
                closeLife = true;
            }
        }
        else
        {
            closeLife = false;
        }
    }
}
