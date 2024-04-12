using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedYAxis : MonoBehaviour
{
    // to know which tracked head (player 1 (1) vs player 2 (10))
    public int headID;

    // empty game object to be turned
    public GameObject emptyHead;

    // Update is called once per frame
    void Update()
    {
        // fetch rotation of head tracking
        Vector3 headRotation = CAVE2.GetHeadRotation(headID).eulerAngles;

        // apply y rotation to empty game object
        emptyHead.transform.localEulerAngles = new Vector3(0, headRotation.y, 0);
    }
}
