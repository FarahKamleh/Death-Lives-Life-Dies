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

    // wall to be raised
    public GameObject wall;

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

            // use x position to raise wall and remove assistant
            if (gameObject.transform.position.x == otherTarget.position.x)
            {
                // raise wall of opposing player and make assistant disappear
                wall.SetActive(true);
                StartCoroutine(MoveFunctionUp());
            }
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

    // move the wall
    IEnumerator MoveFunctionUp()
    {
        // detatch trees from parent
        wall.transform.parent = null;
        float totalTime = 3;
        float elapsedTime = 0;

        while (true)
        {
            // gradually make the wall rise at the speed of time
            elapsedTime += Time.deltaTime;
            wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, 1, wall.transform.position.z), elapsedTime / totalTime);

            // if the wall reached the desired height, exit
            if (wall.transform.position == new Vector3(wall.transform.position.x, 1, wall.transform.position.z))
            {
                // exit
                wall.GetComponent<TreeWallController>().activated = true;

                // make assistant disappear
                gameObject.SetActive(false);
                yield break;
            }

            yield return null;
        }
    }

}

