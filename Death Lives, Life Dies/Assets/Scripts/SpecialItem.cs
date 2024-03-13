using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    // to switch between special items in the corner
    public SpriteRenderer emptySprite;
    public SpriteRenderer wallSprite;

    // integer to track which special item is in holder
    int itemNum;

    // wall game object
    public GameObject wall;

    // target position
    Vector3 targetPos = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        // start with 0 because there is no special item
        itemNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if the user presses the space bar or L2
        if ((Input.GetKeyDown("up")) || (CAVE2.GetButtonDown(CAVE2.Button.Button7)))
        {
            /* check which item is held */

            // if special item is wall
            if (itemNum == 1)
            {
                // switch the sprites
                emptySprite.enabled = true;
                wallSprite.enabled = false;

                // make wall rise until it reaches target height
                StartCoroutine(MoveFunctionUp());
            }
        }
    }

    // enter if a collision occurs with the CAVE2
    private void OnCollisionEnter(Collision collision)
    {
        // if the collision is with wall special item
        if (collision.gameObject.tag == "WallItem")
        {
            // destroy the special item
            Destroy(collision.gameObject);

            // swap the special item image to the tombstone
            emptySprite.enabled = false;
            wallSprite.enabled = true;

            // reassign the item number
            itemNum = 1;
        }
    }

    // move the wall
    IEnumerator MoveFunctionUp()
    {
        while (true)
        {
            // gradually make the wall rise at the speed of time
            wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, 1, wall.transform.position.z), Time.deltaTime);

            // if the wall reached the desired height, exit
            if (wall.transform.position == new Vector3(wall.transform.position.x, 1, wall.transform.position.z))
            {
                yield break;
            }

            yield return null;
        }
    }
}