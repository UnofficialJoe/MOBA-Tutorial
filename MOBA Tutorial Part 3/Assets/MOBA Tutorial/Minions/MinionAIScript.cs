using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIScript : MonoBehaviour
{
    public Vector3 destination;
    public Vector3 finalDestination;

    public Material blueMinionMat;
    public Material redMinionMat;

    public bool isBlue;

    public GameObject targetMinion;
    public bool hasTarget = false;
    public bool passedHalfway = false;

    public float health = 100;
    public float attackTimer = 2;
    
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        if (isBlue)
        {
            this.gameObject.GetComponent<Renderer>().material = blueMinionMat;
            this.gameObject.layer = 9;
        } else
        {
            this.gameObject.GetComponent<Renderer>().material = redMinionMat;
            this.gameObject.layer = 10;
        }

        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget && targetMinion != null)
        {
            agent.SetDestination(targetMinion.transform.position);
            attackTimer = attackTimer - Time.deltaTime;
            if(attackTimer <= 0)
            {
                attackTimer = 2;
                targetMinion.GetComponent<MinionAIScript>().health -= 30;
                Debug.Log("Health" + health);
            }
            
        }

        
        if(targetMinion == null)
        {

            hasTarget = false;

            if (passedHalfway)
            {
                agent.SetDestination(finalDestination);
            } else
            {
                agent.SetDestination(destination);
            }
            
        }

        
        // Top Lane Destination true
        if(this.transform.position.x <= -44 && this.transform.position.z >= 44)
        {
            agent.SetDestination(finalDestination);
            passedHalfway = true;
        }
        // Bot Lane Destination true
        if (this.transform.position.x >= 44 && this.transform.position.z <= -44)
        {
            agent.SetDestination(finalDestination);
            passedHalfway = true;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

}
