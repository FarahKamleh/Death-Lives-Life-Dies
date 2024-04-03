using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewbornTargetScript : MonoBehaviour
{
    [SerializeField] Transform lifeTransform;
    [SerializeField] Transform deathTransform;
    [SerializeField] Transform newbornTransform;

    // Landmarks
    [SerializeField] Transform altarTransform;

    float lifeDistance;
    float deathDistance;
    [SerializeField] bool cooldownStatus;
    [SerializeField] float cooldownDuration;
    Transform targetTransform;
    Quaternion targetRotation;
    float randDist;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeDistance = Vector3.Distance(lifeTransform.position, newbornTransform.position);
        deathDistance = Vector3.Distance(deathTransform.position, newbornTransform.position);

        //if ((lifeDistance < 10) && (deathDistance < 10))
        if (!cooldownStatus)
        {
            if ((lifeDistance < 0) && (deathDistance < 0))
            {
                // Head towards a random landmark, but Altar, for now
                targetTransform.position = altarTransform.position;
            }
            else if (lifeDistance < deathDistance)
            {
                // Run away from life

                Vector3 direction = -(lifeTransform.position - newbornTransform.position).normalized;
                direction = applyRandomAngle(direction);
                targetTransform.position = newbornTransform.position + direction;

            }
            else
            {
                // Run away from death
                Vector3 direction = -(deathTransform.position - newbornTransform.position).normalized;
                direction = applyRandomAngle(direction);
                targetTransform.position = newbornTransform.position + direction;
            }
        }
    }

    Vector3 applyRandomAngle(Vector3 direction)
    {
        if (!cooldownStatus)
        {
            randDist = Random.Range(10.0f, 20.0f);
            targetRotation = Quaternion.AngleAxis(Random.Range(-60.0f, 60.0f), Vector3.up);
            cooldownStatus = true;
            StartCoroutine(cooldown());
        }
        float dotProduct = Vector3.Dot(targetRotation * direction, direction);
        float mag = Vector3.Magnitude(targetRotation * direction);
        Vector3 newDirection;
        newDirection = ((targetRotation * direction) * (dotProduct / mag)).normalized;
        newDirection *= randDist;
        //Vector3 newPosition = newbornTransform.position + newDirection;
        //while (newPosition.x > 66 || newPosition.x < -66 || newPosition.z < -66 || newPosition.z > 66)
        //{
        //    targetRotation = Quaternion.AngleAxis(Random.Range(-180.0f, 180.0f), Vector3.up);
        //    newDirection = ((targetRotation * direction) * (dotProduct / mag)).normalized;
        //    newDirection *= Random.Range(0.0f, 20.0f); 
        //}
        return newDirection;
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldownStatus = false;
    }
}
