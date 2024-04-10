using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehavior : MonoBehaviour
{

    public float interactionCooldown;
    public bool onCooldown = false;

    [SerializeField] AudioSource treeHitSound;
    [SerializeField] AudioSource newbornHitSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onCooldown == true) {
            StartCoroutine(doCooldown());
        }
    }

    IEnumerator doCooldown() {
        yield return new WaitForSeconds(interactionCooldown);
        onCooldown = false;
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ScytheTarget" && onCooldown == false) {
            if (other.gameObject.name == "Newborn Hitbox") newbornHitSound.Play();
            if (other.gameObject.name == "Hitbox Trees") treeHitSound.Play();

            if (other.gameObject.GetComponent<CharacterInfo>().health > 0) {
                other.gameObject.GetComponent<CharacterInfo>().health -= 1;
                Debug.Log("Target Health at " + other.gameObject.GetComponent<CharacterInfo>().health);
            }

            onCooldown = true;
        }
    }

}
