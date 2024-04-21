using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedYAxis : MonoBehaviour
{
    // to know which tracked head (player 1 (1) vs player 2 (10))
    public int headID;

    // empty game object to be turned
    public GameObject emptyHead;

    // store previous head rotation
    Vector3 prevRotation;

    // store head tracked position always
    Vector3 headRotation;

    private void Start()
    {
        // store the initial rotation of the player's head
        prevRotation = CAVE2.GetHeadRotation(headID).eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // fetch rotation of head tracking
        headRotation = CAVE2.GetHeadRotation(headID).eulerAngles;

        // if the y rotation has been changed more than 2
        if ((headRotation.y > (prevRotation.y + 2)) || (headRotation.y < (prevRotation.y - 2)))
        {
            // apply y rotation to empty game object
            emptyHead.transform.localEulerAngles = new Vector3(0, headRotation.y, 0);

            // update the previous y head position
            prevRotation = headRotation;
        }
    }
}