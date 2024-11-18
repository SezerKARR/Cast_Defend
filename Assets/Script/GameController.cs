using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Texture2D[] cursorArrow;
    [SerializeField] private  float dayTime;
    [SerializeField] private SpriteRenderer backGround;
    [SerializeField] private GameObject[] enemyPrefab;
    private float timeBetweenWaves = 2f;
    public float countDown = 2f;
    [SerializeField] Color endcolor;
    public float timer;
    [SerializeField] GameObject hitmanPrefab;
    List<GameObject> hitmans=new List<GameObject>();
    // Start is called before the first frame update
    private Vector2 cursorPos;
    public static List<GameObject> enemys=new List<GameObject>();
    public static List<Collider2D> contacts = new List<Collider2D>();
    void Start()
    {
        enemys.Clear();
        hitmans.Clear();
        float posDist = 5f / ((float)SetStats.ammor + 1f);
        for (int i = 0; i < SetStats.ammor; i++)
        {
            GameObject hitman = Instantiate(hitmanPrefab, new Vector3(7.65f , (3 - (posDist*(i+1))), 0), Quaternion.identity);
            Debug.Log(hitman);
            
            hitmans.Add(hitman);
        }
        
        timer = 0;
        cursorPos = new Vector2(cursorArrow[0].width / 2, cursorArrow[0].height / 2);
        Cursor.SetCursor(cursorArrow[0], cursorPos, CursorMode.ForceSoftware);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            countDown = timeBetweenWaves;
            for (int i = 0; i < Random.RandomRange(1, 3); i++)
            {
                Instantiate(enemyPrefab[Random.RandomRange(0, enemyPrefab.Length)], new Vector3(-12 + Random.RandomRange(-2, 2), Random.RandomRange(-4, 1), 0), Quaternion.identity);
                i = 0;
            }
            

        }
        else
        {
            countDown -= Time.deltaTime;
        }


        backGround.color = Color.Lerp(backGround.color, endcolor, Time.deltaTime *(1f/dayTime));
        timer += Time.deltaTime;
        if (dayTime <= timer)
        {
            SceneManager.LoadScene(1);
        }
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        UpdateEnemy();

   }
    
    public  void UpdateEnemy()
    {
        contacts.Clear();
        GameController.enemys.Clear();

        gameObject.GetComponent<BoxCollider2D>().GetContacts(contacts);

        for (int i = 0; i < contacts.Count; i++)
        {
            Debug.Log("geldi;");
            if (contacts[i] != null && contacts[i].gameObject.CompareTag("Enemy"))
            {
                GameController.enemys.Add(contacts[i].gameObject);

            }
            else if (contacts[i] == null)
            {
                break;
            }
        }
    }
     /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("geldi");
    }*/
}
