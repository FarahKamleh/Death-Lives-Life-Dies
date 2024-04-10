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
    Transform[] landmarks;
    [SerializeField] Transform altarTransform;
    [SerializeField] Transform flowerGardenTransform;
    [SerializeField] Transform fountainTransform;
    [SerializeField] Transform graveyardTransform;
    [SerializeField] Transform pastureTransform;
    [SerializeField] Transform pondTransform;
    [SerializeField] Transform skullTowerTransform;

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
        landmarks = new[] {
                    altarTransform,
                    flowerGardenTransform,
                    fountainTransform,
                    graveyardTransform,
                    pastureTransform,
                    pondTransform,
                    skullTowerTransform
        };
    }

    // Update is called once per frame
    void Update()
    {
        lifeDistance = Vector3.Distance(lifeTransform.position, newbornTransform.position);
        deathDistance = Vector3.Distance(deathTransform.position, newbornTransform.position);

        //if ((lifeDistance < 10) && (deathDistance < 10))
        if (!cooldownStatus)
        {
            if ((lifeDistance < 5) && (deathDistance < 5))
            {
                // Head towards a random landmark
                Vector3 center = average(lifeTransform.position, deathTransform.position);
                targetTransform.position = getFurthestLandmarkTransform(center);
                cooldownStatus = true;
                StartCoroutine(cooldown());
            }
            else if (lifeDistance < deathDistance)
            {
                // Run away from life

                Vector3 direction = -(lifeTransform.position - newbornTransform.position).normalized;
                direction = applyRandomAngle(direction, "life");
                targetTransform.position = direction;
                //targetTransform.position = average(targetTransform.position, getFurthestLandmarkTransform(lifeTransform.position).position);
            }
            else
            {
                // Run away from death
                Vector3 direction = -(deathTransform.position - newbornTransform.position).normalized;
                direction = applyRandomAngle(direction, "death");
                targetTransform.position = direction;
                //targetTransform.position = average(targetTransform.position, getFurthestLandmarkTransform(deathTransform.position).position);
            }
        }
    }

    Vector3 average(Vector3 a, Vector3 b)
    {
        Vector3 center = new Vector3((a.x + b.x) / 2.0f, (a.y + b.y) / 2.0f, (a.z + b.z) / 2.0f);
        return center;
    }

    Vector3 getFurthestLandmarkTransform(Vector3 target)
    {
        Transform furthest = null;
        float furthestDistance = float.MinValue;

        for (int i = 0; i < landmarks.Length; i++)
        {
            Transform landmark = landmarks[i];

            //float currDistance = Vector3.Distance(lifeTransform.position, landmark.position) + Vector3.Distance(deathTransform.position, landmark.position);
            float currDistance = Vector3.Distance(target, landmark.position);

            if (currDistance > furthestDistance)
            {
                furthest = landmark;
                furthestDistance = currDistance;
            }
        }

        Debug.Log(furthest);
        return furthest.position;
    }

    Vector3 applyRandomAngle(Vector3 direction, string target)
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

        Vector3 newPosition = newbornTransform.position + newDirection;
        if (newPosition.x > 66 || newPosition.x < -66 || newPosition.z < -66 || newPosition.z > 66)
        {
            //targetRotation = Quaternion.AngleAxis(Random.Range(-180.0f, 180.0f), Vector3.up);
            //newDirection = ((targetRotation * direction) * (dotProduct / mag)).normalized;
            //newDirection *= Random.Range(0.0f, 20.0f); 
            if (target == "life")
                return getFurthestLandmarkTransform(lifeTransform.position);
            else if (target == "death")
                return getFurthestLandmarkTransform(deathTransform.position);
        }
        return newPosition;
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldownStatus = false;
    }
}
