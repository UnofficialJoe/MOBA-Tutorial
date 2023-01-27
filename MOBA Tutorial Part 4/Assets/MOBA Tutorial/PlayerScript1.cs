using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript1 : MonoBehaviour
{
    public Camera mainCam;
    int layerGround = 8;
    int layerBlueMinion = 9;
    //int layerRedMinion = 10;
    float attackTimer = 2;
    public float health = 300;
    public float range = 5;
    GameObject target;
    bool hasTarget = false;
    public GameObject moveIcon;
    NavMeshAgent myNavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.layer == layerGround)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Vector3 offset = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
                        Instantiate(moveIcon, offset, Quaternion.identity);
                    }

                    myNavMeshAgent.SetDestination(hit.point);
                    myNavMeshAgent.stoppingDistance = 0;
                    hasTarget = false;

                }

                if(hit.collider.gameObject.layer == layerBlueMinion)
                {
                    target = hit.collider.gameObject;
                    hasTarget = true;
                }
            }
        }

        if (hasTarget && target != null)
        {
            myNavMeshAgent.SetDestination(target.transform.position);
            myNavMeshAgent.stoppingDistance = range;
        }

        if (target != null)
        {
            if(Vector3.Distance(gameObject.transform.position, target.transform.position) <= range)
            {
                attackTimer -= Time.deltaTime;
                if(attackTimer <=0)
                {
                    attackTimer = 2;
                    target.GetComponent<MinionAIScript>().health -= 30;
                    Debug.Log(target.GetComponent<MinionAIScript>().health);
                }
            }
        }
        
    }
}