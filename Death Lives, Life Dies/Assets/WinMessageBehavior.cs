using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMessageBehavior : MonoBehaviour
{

    public GameObject lifeWinText;
    public GameObject deathWinText;

    public GameObject deathHealthObject;
    public GameObject newbornHealthObject;

    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deathHealthObject.GetComponent<CharacterInfo>().health <= 0 && hasWon == false) {
            lifeWinText.SetActive(true);
            hasWon = true;
        }
        if (newbornHealthObject.GetComponent<CharacterInfo>().health <= 0 && hasWon == false) {
            deathWinText.SetActive(true);
            hasWon = true;
        }
    }
}
