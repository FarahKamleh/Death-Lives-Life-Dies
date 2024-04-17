using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{

    public GameObject Death;
    public GameObject Newborn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Death.GetComponent<CharacterInfo>().health == 0) {
            SceneManager.LoadScene("Win Scene Life");
        }
        if (Newborn.GetComponent<CharacterInfo>().health == 0) {
            SceneManager.LoadScene("Win Scene Death");
        }
        
    }
}
