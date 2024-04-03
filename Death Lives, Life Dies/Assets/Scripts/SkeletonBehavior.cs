using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SkeletonBehavior : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private Animator anim;

    public float deathTime;  // time assistant lasts once walking toward target

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("DeathPlayer")) {
            anim.SetBool("Walking", true);
            agent.SetDestination(target.position);
            StartCoroutine(WalkUntilDeath());
        }
        else if (other.gameObject.CompareTag("LifePlayer")) {
            // TODO: Farah, react to life here with tombstones!
        }
    }

    private IEnumerator WalkUntilDeath() {  // kill after interval
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
    }

}

