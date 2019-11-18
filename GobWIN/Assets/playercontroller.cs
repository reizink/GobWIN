using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class playercontroller : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    bool amSelected;
    public SpriteRenderer mySprite;
    public Color selectedColor;
    public Color notSelectedColor;
    Vector3 destination;
    AnimationController animationController;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<AnimationController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (amSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    destination = hit.point;
                    if(hit.transform.tag == "Enemy")
                    {
                        destination = hit.transform.position;
                    }
                }
            }

        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        navMeshAgent.SetDestination(destination);
    }
    public void SetSelected()
    {
        if (amSelected == true)
        {
            amSelected = false;
            mySprite.color = notSelectedColor;
        }
        else
        {
            amSelected = true;
            mySprite.color = selectedColor;
        }
    }
    private void OnTriggerStay(Collider other)
    { 
        if (other.tag == "Enemy")
        {
            if (Vector3.Distance(transform.position, other.transform.position) <= 1)
            {
                destination = transform.position;
                animationController.AttackingAnimation(other.transform.position - transform.position);
                other.GetComponent<EnemyHealth>().DealDamage(20);
            }
            else
            {
                destination = other.transform.position;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animationController.CancelAttack();
    }
}
