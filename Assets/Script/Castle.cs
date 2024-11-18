using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour ,IDamageAble
{
    [SerializeField] float health = 100;
    [SerializeField] Transform castleHealthBar;
    private float startHealth;
    public void TakeDamage(float damage)
    {

        health -= damage;
        HealthBarUpdate();
        if (health < 0)
        {
            health = 0;
            HealthBarUpdate();
        }
        
        
    }
    private void HealthBarUpdate()
    {
        castleHealthBar.localScale = new Vector3(health / startHealth, castleHealthBar.localScale.y, castleHealthBar.localScale.z);

    }
    // Start is called before the first frame update
    void Start()
    {
        startHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < startHealth)
            health += 0.1f * SetStats.healer;
    }
}
