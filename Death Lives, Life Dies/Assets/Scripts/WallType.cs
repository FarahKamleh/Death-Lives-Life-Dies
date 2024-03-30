using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallType : MonoBehaviour
{

    public bool isLife = false;
    public GameObject lifeWall;
    public GameObject deathWall;

    // Start is called before the first frame update
    void Start()
    {
        if (isLife) {
            lifeWall.SetActive(true);
            deathWall.SetActive(false);
        } else {
            lifeWall.SetActive(false);
            deathWall.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
