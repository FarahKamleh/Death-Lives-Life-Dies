using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AssistantBehavior : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private Transform otherTarget;


    public bool lifeAssistant;

    private Animator anim;

    public float deathTime;  // time assistant lasts once walking toward target
    private bool followTarget;
    private bool followOther;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        followTarget = false;
    }


    void Update()
    {
        if (followTarget) {
            agent.SetDestination(target.position);
        }
        if (followOther)
        {
            agent.SetDestination(otherTarget.position);
        }
    }



    void OnTriggerEnter(Collider other) {
        if ((lifeAssistant == false && other.gameObject.CompareTag("DeathPlayer")) || (lifeAssistant == true) && other.gameObject.CompareTag("LifePlayer")) {
            anim.SetBool("Walking", true);
            followTarget = true;
            StartCoroutine(WalkUntilDeath());
        }
        else if ((lifeAssistant == false && other.gameObject.CompareTag("LifePlayer")) || (lifeAssistant == true) && other.gameObject.CompareTag("DeathPlayer")) {
            anim.SetBool("Walking", true);
            followOther = true;
        }
    }

    private IEnumerator WalkUntilDeath() {  // kill after interval
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
    }

}

