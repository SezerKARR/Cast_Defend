using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem current;
    public ToolTip[] toolTip;
    private void Awake()
    {
        current = this;
    }
    public static void Show(string content,string header="")
    {
        current.toolTip[0].SetText(content, header);
        current.toolTip[0].gameObject.SetActive(true);

    }

    public static void Show(string str, string speed, string maxMuzzle, string describeNot, Sprite sprite, string name = "" )
    {
        current.toolTip[1].SetText(str,speed,maxMuzzle,describeNot,sprite,name);
        current.toolTip[1].gameObject.SetActive(true);

    }
    public static void Hide()
    {
        current.toolTip[0].gameObject.SetActive(false);
        current.toolTip[1].gameObject.SetActive(false);
    }
}
