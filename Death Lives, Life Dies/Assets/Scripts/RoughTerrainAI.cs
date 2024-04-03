using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RoughTerrainAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    [SerializeField] private Transform lifePosition;
    [SerializeField] private Transform deathPosition;

    [SerializeField] private bool doSwitch;
    [SerializeField] private float switchInterval;

    private void Start() {
        Random.seed = System.DateTime.Now.Millisecond;  // randomness seed
        if (Random.Range(0.0f, 1.0f) < 0.5f) {  // choose starting target
            target = deathPosition;
        } else {
            target = lifePosition;
        }
        doSwitch = true;  // enable switch coroutine
    }
    private void Update() {  // set destination to target player, start switch coroutine
        if (target != null) {
            agent.SetDestination(target.position);
        }

        if (doSwitch == true) {
            doSwitch = false;  // disable coroutine until finished
            StartCoroutine(PlayerSwitch());
        }
    }

    private IEnumerator PlayerSwitch() {  // choose a random switch interval and switch target after
        switchInterval = Random.Range(20.0f, 45.0f);
        yield return new WaitForSeconds(switchInterval);
        if (target == deathPosition) {
            target = lifePosition;
        } else {
            target = deathPosition;
        }
        doSwitch = true;  // re-enable switch coroutine
    }

}
