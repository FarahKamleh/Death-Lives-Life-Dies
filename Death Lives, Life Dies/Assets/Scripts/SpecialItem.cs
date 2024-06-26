﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    // to switch between special items in the corner
    public SpriteRenderer wallSprite;

    // integer to track which special item is in holder
    int itemNum;

    // wall game object
    public GameObject wall;

    // target position
    Vector3 targetPos = new Vector3(0, 1, 0);

    // to know which controller/player
    int wandID;

    // audio source for wall rising
    public AudioSource wallSound;

    public AudioSource itemPickupSound;

    // Start is called before the first frame update
    void Start()
    {
        // start with 0 because there is no special item
        itemNum = 0;

        // check which player script is attached to
        if (gameObject.tag == "DeathPlayer")
        {
            // set wand to 1
            wandID = 1;
        }
        if (gameObject.tag == "LifePlayer")
        {
            // set wand to 2
            wandID = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the user presses the space bar or L2
        if ((Input.GetKeyDown("up")) || (CAVE2.GetButtonDown(CAVE2.Button.Button7, wandID)))
        {
            /* check which item is held */

            // if special item is wall
            if (itemNum == 1)
            {
                // remove the wall sprite
                wallSprite.enabled = false;

                // enable the wall
                wall.SetActive(true);

                // make wall rise until it reaches target height
                StartCoroutine(MoveFunctionUp());

                // reset item number
                itemNum = 0;
            }
        }
    }

    // enter if a collision occurs with the CAVE2
    private void OnCollisionEnter(Collision collision)
    {
        // if the collision is with wall special item
        if (collision.gameObject.tag == "WallItem")
        {
            // Play pickup sound
            itemPickupSound.Play();
            // destroy the special item
            Destroy(collision.gameObject);

            // add the wall sprite
            wallSprite.enabled = true;

            // reassign the item number
            itemNum = 1;
        }
    }

    // move the wall
    IEnumerator MoveFunctionUp()
    {
        // detatch trees from parent
        wall.transform.parent = null;
        float totalTime = 3;
        float elapsedTime = 0;

        // play rising sound
        wallSound.Play();

        while (true)
        {
            // gradually make the wall rise at the speed of time
            elapsedTime += Time.deltaTime;
            wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, 1, wall.transform.position.z), elapsedTime / totalTime);

            // if the wall reached the desired height, exit
            if (wall.transform.position == new Vector3(wall.transform.position.x, 1, wall.transform.position.z))
            {
                // exit
                wall.GetComponent<TreeWallController>().activated = true;
                yield break;
            }

            yield return null;
        }
    }
}