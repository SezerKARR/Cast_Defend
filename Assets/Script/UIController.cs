using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public Text rentOfDay;
    public static float wholeRent;
    private int healer;
    private int ammor;
    public static float money;

    public  GameObject[] silah;
    [SerializeField] Text moneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SetStats.purchased.Count == 0)
        {

            for (int i = 0; i < silah.Length; i++)
            {

                SetStats.purchased.Add(false);
                
            }
        }
        else
        {
            for (int i = 0; i < silah.Length; i++)
            {
                if (SetStats.purchased[i]== true)
                {
                    silah[i].transform.Find("Image").gameObject.SetActive(false);
                }



            }
        }


        moneyText.text = (SetStats.wholeMoney + (float)(money-wholeRent)).ToString();
        rentOfDay.text = wholeRent.ToString();
        SetStats.wholeMoney = float.Parse(moneyText.text);
    }
    public void Muzzle()
    {
        SetStats.increaseMuzzle += 1;
    }
    public  void changeColor()
    {
        for(int i = 0; i < silah.Length; i++)
        {
            silah[i].GetComponent<Image>().color = Color.white;
        }
    }
    public  void UpdateMoney(float money)
    {
        SetStats.wholeMoney = float.Parse(moneyText.text) + money;
        moneyText.text =SetStats.wholeMoney.ToString() ;
    }
    public void UpdateRent(float rent)
    {
        wholeRent += rent;
        rentOfDay.text = wholeRent.ToString();
       
    }
    public void IncreaseHealer()
    {
        healer++;
        SetStats.healer = this.healer;
    }
    public void IncreaseAmmor()
    {
        ammor++;
        SetStats.ammor = this.ammor;
    }
    public void Play()
    {

        SceneManager.LoadScene(0);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
