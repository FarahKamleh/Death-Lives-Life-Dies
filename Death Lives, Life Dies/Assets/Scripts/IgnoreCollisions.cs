using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    // gameobjects whose colliders are of interest
    public GameObject deathBody;
    public GameObject scythe;

    // Start is called before the first frame update
    void Start()
    {
        // ensure death body and scythe do not collide
        Physics.IgnoreCollision(deathBody.GetComponent<Collider>(), scythe.GetComponent<Collider>());
    }
}
