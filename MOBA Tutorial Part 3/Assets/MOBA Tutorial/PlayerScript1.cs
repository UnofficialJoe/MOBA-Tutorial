using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript1 : MonoBehaviour
{
    public Camera mainCam;
    public int layer = 8;
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
                if (hit.collider.gameObject.layer == layer)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Vector3 offset = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
                        Instantiate(moveIcon, offset, Quaternion.identity);
                    }
                    
                    myNavMeshAgent.SetDestination(hit.point);
                    
                }
            }
        }
    }
}
