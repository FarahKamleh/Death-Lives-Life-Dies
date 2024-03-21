using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWallController : MonoBehaviour
{
    [SerializeField]
    GameObject Hitbox;
    [SerializeField]
    float health;
    [SerializeField]
    public bool activated;

    Vector3 downPosition = new Vector3(0, -3.57f, 0);
    Vector3 upPosition = new Vector3(0, 1.0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update transform x and z positions
        downPosition.x = gameObject.transform.position.x;
        downPosition.z = gameObject.transform.position.z;
        upPosition.x = gameObject.transform.position.x;
        upPosition.z = gameObject.transform.position.z;

        // Update health to current health
        health = Hitbox.GetComponent<CharacterInfo>().health;
        if (activated)
            gameObject.transform.position = Vector3.Lerp(downPosition, upPosition, health / 5.0f);
    }
}
