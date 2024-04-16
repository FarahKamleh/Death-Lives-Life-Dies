using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AssistantBehavior : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private Transform otherTarget;
    [SerializeField] private AudioSource goodSound;
    [SerializeField] private AudioSource badSound;

    public bool lifeAssistant;

    private Animator anim;

    public float deathTime;  // time assistant lasts once walking toward target
    private bool followTarget;
    private bool followOther;


    public GameObject bubbleIdle;
    public GameObject bubbleChase;
    public GameObject bubbleNewborn;
    public GameObject bubbleDeath;


    public GameObject p1Camera;
    

    // wall to be raised
    public GameObject wall;

    // audio source of wall
    public AudioSource wallSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        followTarget = false;
        bubbleIdle.SetActive(true);
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

        bubbleIdle.transform.forward = p1Camera.transform.forward;
        bubbleChase.transform.forward = p1Camera.transform.forward;
        bubbleNewborn.transform.forward = p1Camera.transform.forward;
        bubbleDeath.transform.forward = p1Camera.transform.forward;

    }



    void OnTriggerEnter(Collider other) {
        // If the assistant is the nearby player's assistant, the assistant chases the target
        if ((lifeAssistant == false && other.gameObject.CompareTag("DeathPlayer")) || (lifeAssistant == true) && other.gameObject.CompareTag("LifePlayer")) {
            anim.SetBool("Walking", true);
            followTarget = true;

            bubbleIdle.SetActive(false);  // change speech bubble depending on player's target
            if (lifeAssistant == false) {
                bubbleNewborn.SetActive(true);
            } else {
                bubbleDeath.SetActive(true);
            }
            goodSound.Play();
            StartCoroutine(WalkUntilDeath());
        }
        // Otherwise, chase the person to came nearby 
        else if ((lifeAssistant == false && other.gameObject.CompareTag("LifePlayer")) || (lifeAssistant == true) && other.gameObject.CompareTag("DeathPlayer")) {
            anim.SetBool("Walking", true);

            bubbleIdle.SetActive(false);
            bubbleChase.SetActive(true);

            followOther = true;
            badSound.Play();
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

        // play wall sound
        wallSound.Play();

        while (true)
        {
            // gradually make the wall rise at the speed of time and
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

