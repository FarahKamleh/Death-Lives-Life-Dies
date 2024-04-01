﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    GameObject bowObject;

    Vector3 initialPos;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        initialPos = bowObject.transform.position;   

        if (!active)
        {
            gameObject.GetComponent<Rigidbody>().Sleep();
            gameObject.transform.position = initialPos;
            gameObject.transform.rotation = bowObject.transform.rotation;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().WakeUp();
        }
    }

    public void setActive(bool state) { active = state; }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BowTarget" && active == true)
        {
            if (other.gameObject.GetComponent<CharacterInfo>().health > 0)
            {
                other.gameObject.GetComponent<CharacterInfo>().health -= 1;
                Debug.Log("Target Health at " + other.gameObject.GetComponent<CharacterInfo>().health);
            }
        }
    }
}