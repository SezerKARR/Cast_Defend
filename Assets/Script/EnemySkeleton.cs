using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : MonoBehaviour,IDamageAble
{
   
    public  Animator anim;
    public  Rigidbody2D rb;
    public  float health;
    public GameObject Castle;
    public GameObject blood;
    private bool circle=false;
    private int posEnemy;
    [SerializeField] Transform healthBar;
    private float startHealth;
    [SerializeField] float money;
    // Start is called before the first frame update
    public virtual void Start()
    {
        startHealth = health;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim=gameObject.GetComponent<Animator>();
       
    }
    
    // Update is called once per frame
    public virtual void Update()
    {
        if (gameObject.transform.position.y > 1f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x,1f);
        }
        if (gameObject.transform.position.y < -4f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -4f);
        }
        rb.velocity = new Vector2(1, 0);
    }
    
  
    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            Castle = collision.gameObject;
            anim.SetBool("attack", true);
        }
        
    }
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.localScale = new Vector3(health / startHealth, healthBar.localScale.y, healthBar.localScale.z);
        
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().UpdateEnemy();
            SetStats.UpdateMoney(money);
            Instantiate(blood, new Vector3(transform.position.x + Random.RandomRange(-1, 1), transform.position.y + 2, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public virtual void GiveDamage(float damage)
    {
        var IDamageAble = Castle.GetComponent<IDamageAble>();
        if (IDamageAble == null) return;

        IDamageAble.TakeDamage(damage);
        
        
    }
}
