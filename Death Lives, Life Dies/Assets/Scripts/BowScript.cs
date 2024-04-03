using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    [SerializeField]
    GameObject bulletObject;
    [SerializeField]
    float cooldown;

    Rigidbody rb;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        // EDIT: make sure L1 is pressed from Player 2's wand
        if (((Input.GetMouseButtonDown(0)) || (CAVE2.GetButtonDown(CAVE2.Button.Button5, 2))) && (active == false))
        {
            Debug.Log("Fired");
            active = true;
            bulletObject.GetComponent<BulletScript>().setActive(true);
            bulletObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            bulletObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
           // bulletObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            bulletObject.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * -1500);
            StartCoroutine(deactivateBullet());
        }
    }

    IEnumerator deactivateBullet()
    {
        float elapsedTime = 0;

        while (true)
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime > cooldown)
            {
                active = false;
                bulletObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                bulletObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
               // bulletObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                bulletObject.GetComponent<BulletScript>().setActive(false);
                //bulletObject.GetComponent<Rigidbody>().Sleep();
                //bulletObject.GetComponent<Rigidbody>().WakeUp();
                Debug.Log("Reset");
                yield break;
            }

            yield return null;
        }
    }
}
