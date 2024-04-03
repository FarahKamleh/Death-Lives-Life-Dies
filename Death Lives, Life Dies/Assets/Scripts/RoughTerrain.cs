using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoughTerrain : MonoBehaviour
{

    public float slowMoveSpeed;
    private float normalMoveSpeed;

    void Start()
    {
        normalMoveSpeed = gameObject.GetComponent<CAVE2WandNavigator>().movementScale;
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("RoughTerrain")) {
            gameObject.GetComponent<CAVE2WandNavigator>().movementScale = slowMoveSpeed;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("RoughTerrain")) {
            gameObject.GetComponent<CAVE2WandNavigator>().movementScale = normalMoveSpeed;
        }
    }

}
