using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ToolTipItemTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] Sprite item;
    [SerializeField] string itemName;
    [SerializeField] string str;
    [SerializeField] string speed;
    [SerializeField] string maxMuzzle;
    [SerializeField] string magazineTime;
    [SerializeField] string describeNot;
    [SerializeField] bool auto;
    [SerializeField] Text money;
    private  bool purchased=false;
    private int posGameObject;
    UIController uIController;
    private void Start()
    {
        uIController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        if (itemName != "")
        {

            ToolTipSystem.Show(str, speed, maxMuzzle, describeNot, item, itemName);
        }

    }

    // Update is called once per frame
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < uIController.silah.Length; i++)
        {
            if (uIController.silah[i] == gameObject)
            {
                posGameObject = i;
            }
        }
        ToolTipSystem.Hide();
        if (SetStats.wholeMoney >= float.Parse(money.text) && !SetStats.purchased[posGameObject])
        {

            //GameObject.FindGameObjectWithTag("GameController").GetComponent<Player>().SetStats(float.Parse(str), float.Parse(speed), int.Parse(maxMuzzle), float.Parse(magazineTime), item, auto);
            SetStats.damage = float.Parse(str);
            SetStats.gunSprite = item;
            SetStats.gunSpeed = float.Parse(speed);
            SetStats.maxMuzzle = int.Parse(maxMuzzle);
            SetStats.magazineTime = float.Parse(magazineTime);
            SetStats.auto = auto;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().UpdateMoney(-float.Parse(money.text));
            uIController.changeColor();
            gameObject.GetComponent<Image>().color = Color.green;
            gameObject.transform.Find("Image").gameObject.SetActive(false);
            SetStats.purchased[posGameObject] = true;
        }
        else if (!SetStats.purchased[posGameObject])
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (SetStats.purchased[posGameObject])
        {
            SetStats.damage = float.Parse(str);
            SetStats.gunSprite = item;
            SetStats.gunSpeed = float.Parse(speed);
            SetStats.maxMuzzle = int.Parse(maxMuzzle);
            SetStats.magazineTime = float.Parse(magazineTime);
            SetStats.auto = auto;
            uIController.changeColor();
            gameObject.GetComponent<Image>().color = Color.green;

        }
    }
}
