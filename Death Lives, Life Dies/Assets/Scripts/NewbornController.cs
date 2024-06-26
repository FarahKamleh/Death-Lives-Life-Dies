﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewbornController : MonoBehaviour
{
    [SerializeField] GameObject pointLightObject;
    [SerializeField] GameObject sphere;
    [SerializeField] Material brightMaterial;
    [SerializeField] Material darkMaterial;
    [SerializeField] float health;
    [SerializeField] NavMeshAgent agent;

    // Landmarks
    [SerializeField] GameObject altar;

    // Players
    [SerializeField] Transform target;


    Light pointLight;
    Renderer sphereRenderer;
    Color brightColor;
    Color darkColor;

    // Start is called before the first frame update
    void Start()
    {
        brightColor = new Color(255, 251, 64);
        darkColor = new Color(92, 10, 0);
        pointLight = pointLightObject.GetComponent<Light>();
        sphereRenderer = sphere.GetComponent<Renderer>();
        pointLight.color = brightColor;
        sphereRenderer.material = brightMaterial;
        health = 5;
        gameObject.transform.position = altar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        health = sphere.GetComponent<CharacterInfo>().health;
        pointLight.color = Color.Lerp(darkColor, brightColor, health / 5.0f);
        sphereRenderer.material.Lerp(darkMaterial, brightMaterial, health / 5.0f);
    }
}
