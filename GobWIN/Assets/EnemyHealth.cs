using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Variables

    [Header("References")] //property drawers
    public NavMeshAgent agent;
    public Transform destination; //get to treasure
    public GameObject target;

    [Header("Attributes")]
    [Range(0, 50)]
    public float DamageDealt = 5;
    [Range(0, 100)]
    public float Health = 100f;
    public float Speed = 3.5f;
    public float HealOverTime = 1;

    public float DistanceFromTarget = 2f; //minimum distance
    public float distance;

    private GameObject playerObject;
    public GameObject money;
    public GameObject wood;
    public GameObject explodyCrystal;
    int spawnnumber;
    public GameObject[] healthIndicators;
    float max_heath;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        max_heath = Health;
        playerObject = findClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        HealthGen();
        ShowDamage();
        if (target == null)
            agent.SetDestination(destination.position);
        else
            agent.SetDestination(target.transform.position);

        target = playerObject;

        /*if (target.health <= 0) //goblin dies, find new one to attack
        {
            target = findClosestEnemy();
        }*/

    }

    //Created by Andrew Johnson
    //Purpose is to show the damage from the makeshift health bar
    public void ShowDamage()
    {
        if (Health <(4 * (max_heath/5)))
        {
            healthIndicators[0].SetActive(false) ;
            healthIndicators[1].SetActive(true);
            healthIndicators[2].SetActive(true);
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        }
        if (Health <(3 * (max_heath/5)))
        {
            healthIndicators[1].SetActive(false) ;
            healthIndicators[2].SetActive(true);
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        } if (Health <(2 * (max_heath/5)))
        {
            healthIndicators[2].SetActive(false) ;
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        } if (Health <(max_heath/5))
        {
            healthIndicators[3].SetActive(false) ;
            healthIndicators[4].SetActive(true);
        } if (Health <= 0)
        {
            healthIndicators[4].SetActive(false) ;
        }
    }
    //Created By Andrew Johnson
    //Purpose: called to deal damage to the enemy
    public void DealDamage(int damage)
    {
        Health -= damage * Time.deltaTime;
    }
    void HealthGen()
    {
        if (Health <= 0)
        {
            agent.speed = 0;
            Debug.Log("Enemy Destroyed");
            StartCoroutine(die());

        }
        else if (Health <= 80)
        {
            Health += HealOverTime * Time.deltaTime;
        }
    }

    private GameObject findClosestEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestEnemy = null;
        float closestDistance = 1000;
        bool first = true;

        foreach (var obj in objs)
        {
            float distance1 = Vector3.Distance(obj.transform.position, transform.position);

            if (first)
            {
                closestDistance = distance;
                first = false;
            }
            else if (distance1 < closestDistance)
            {
                closestEnemy = obj;
                closestDistance = distance1;
            }
        }

        return closestEnemy;
    }
    //Created by Andrew Johnson
    //Purpose: to carry out all neccessary action to kill the object
    IEnumerator die()
    {
        GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
        yield return new WaitForSeconds(2f);
        spawnnumber = Random.Range(1, 3);
        switch (spawnnumber) {
            case 1:
                Instantiate(money, transform.position, money.transform.rotation);
                break;
            case 2:
                Instantiate(wood, transform.position, wood.transform.rotation);
                break;
            case 3:
                Instantiate(explodyCrystal, transform.position, explodyCrystal.transform.rotation);
                break;
        }
        Destroy(gameObject);
    }
}
