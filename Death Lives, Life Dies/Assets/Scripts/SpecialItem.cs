using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    // to switch between special items in the corner
    public SpriteRenderer empty;
    public SpriteRenderer wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            empty.enabled = false;
            wall.enabled = true;

        }
    }
}
