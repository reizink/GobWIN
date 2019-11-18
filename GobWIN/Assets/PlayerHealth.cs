using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    #region Variables

    [Header("Attributes")]
    [Range(0, 50)]
    public float DamageDealt = 10;
    [Range(0, 100)]
    public float Health = 100f;
    public float HealOverTime = 1;
    public GameObject[] healthIndicators;
    float max_health;
    #endregion

    private void Start()
    {
        max_health = Health;
    }
    // Update is called once per frame
    void Update()
    {
        HealthGen();
        ShowDamage();
    }
    public void ShowDamage()
    {
        if (Health < (4 * (max_health / 5)))
        {
            healthIndicators[0].SetActive(false);
            healthIndicators[1].SetActive(true);
            healthIndicators[2].SetActive(true);
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        }
        if (Health < (3 * (max_health / 5)))
        {
            healthIndicators[1].SetActive(false);
            healthIndicators[2].SetActive(true);
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        }
        if (Health < (2 * (max_health / 5)))
        {
            healthIndicators[2].SetActive(false);
            healthIndicators[3].SetActive(true);
            healthIndicators[4].SetActive(true);
        }
        if (Health < (max_health / 5))
        {
            healthIndicators[3].SetActive(false);
            healthIndicators[4].SetActive(true);
        }
        if (Health <= 0)
        {
            healthIndicators[4].SetActive(false);
        }
    }
    void HealthGen()
    {
        if (Health <= 0)
        {
            Debug.Log("You have died.");
            transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
            StartCoroutine(Die());
        }
        else if(Health <= 80)
        {
            Health += HealOverTime * Time.deltaTime;
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
    public void doDamage(int Damage)
    {
        Health -= Damage * Time.deltaTime;
    }
}
