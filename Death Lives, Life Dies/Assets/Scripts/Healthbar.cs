using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{

    public GameObject characterToWatch;  // "character" to watch (death or newborn)
    public int barVal;  // value displayed on healthbar


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterToWatch.GetComponent<CharacterInfo>().health == barVal) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
