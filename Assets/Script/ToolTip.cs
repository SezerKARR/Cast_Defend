using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;

    public Image item;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI str;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI maxMuzzle;
    public TextMeshProUGUI describeNot;


    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetText(string content,string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;
    }
    public void SetText(string str, string speed, string maxMuzzle, string describeNot, Sprite sprite, string name = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            itemName.gameObject.SetActive(false);
        }
        else
        {
            itemName.gameObject.SetActive(true);
            itemName.text = name;
        }
        this.str.text = str;
        this.speed.text = speed;
        this.maxMuzzle.text = maxMuzzle;
        this.describeNot.text = describeNot;
        this.item.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (headerField.text != "")
        {

            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? false : true;
        }
        if (itemName.text != "")
        {

            int itemNameLenght = itemName.text.Length;
            int describeNotlenght = describeNot.text.Length;

            layoutElement.enabled = (describeNotlenght > characterWrapLimit || itemNameLenght > characterWrapLimit) ? false : true;
        }
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivoty = position.y / Screen.height;
        rectTransform.pivot = new Vector2(pivotX, pivoty);
        transform.position = position;
    }
}
