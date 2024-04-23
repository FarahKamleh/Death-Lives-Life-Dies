using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{

    public GameObject DeathHealth;
    public GameObject Newborn;
    public GameObject Death;
    public GameObject Life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DeathHealth.GetComponent<CharacterInfo>().health == 0 || Newborn.GetComponent<CharacterInfo>().health == 0) {
            Death.transform.position = new Vector3(0f,-29f,10f);
            Life.transform.position = new Vector3(0f,-29f,-10f);
        }
        
    }
}
