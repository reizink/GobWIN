using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
            if(Vector3.Distance(transform.position, other.transform.position) < 1)
            {
                other.GetComponent<PlayerHealth>().doDamage(5);
                print("Attack");
            }
        }
    }
}
