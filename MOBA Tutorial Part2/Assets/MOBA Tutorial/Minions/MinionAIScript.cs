using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIScript : MonoBehaviour
{
    public Vector3 destination;
    public Vector3 finalDestination;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
        this.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        // Top Lane Destination true
        if(this.transform.position.x <= -44 && this.transform.position.z >= 44)
        {
            agent.SetDestination(finalDestination);
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        // Bot Lane Destination true
        if (this.transform.position.x >= 44 && this.transform.position.z <= -44)
        {
            agent.SetDestination(finalDestination);
        }

    }
}
