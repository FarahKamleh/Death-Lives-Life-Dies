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
    [SerializeField]
    bool isTree;

    Vector3 disabledPosition = new Vector3(0, -7.5f, 0);
    Vector3 downPositionTrees = new Vector3(0, -3.57f, 0);
    Vector3 downPositionGraves = new Vector3(0, -1.76f, 0);
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
        downPositionTrees.x = gameObject.transform.position.x;
        downPositionTrees.z = gameObject.transform.position.z;
        downPositionGraves.x = gameObject.transform.position.x;
        downPositionGraves.z = gameObject.transform.position.z;
        upPosition.x = gameObject.transform.position.x;
        upPosition.z = gameObject.transform.position.z;
        disabledPosition.x = gameObject.transform.position.x;
        disabledPosition.z = gameObject.transform.position.z;

        // Update health to current health
        health = Hitbox.GetComponent<CharacterInfo>().health;
        if (activated)
        {
            float total = isTree ? 5.0f : 3.0f;
            Vector3 downPosition = isTree ? downPositionTrees : downPositionGraves;
            gameObject.transform.position = Vector3.Lerp(downPosition, upPosition, health / total);
        }

        if (health == 0)
        {
            gameObject.transform.position = disabledPosition;
            activated = false;

            // make the trees disappear to avoid collisions underneath the ground
            gameObject.SetActive(false);
        }
            
    }
}
