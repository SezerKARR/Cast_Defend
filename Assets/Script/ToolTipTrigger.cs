using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ToolTipTrigger : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler
{
   
    
    public string header;
    public string content;
    [SerializeField] Text money;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (header != ""){
            ToolTipSystem.Show(content, header);
        }
        
    }

    // Update is called once per frame
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (SetStats.wholeMoney >= float.Parse(money.text))
        {

            GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().UpdateMoney(-float.Parse(money.text));

        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
 