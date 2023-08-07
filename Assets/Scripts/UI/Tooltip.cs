using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
[ExecuteInEditMode()]
/*
Tooltip: By Game Dev Guide
From video: Designing a Responsive Tooltip System in Unity
https://www.youtube.com/watch?v=HXFoUGw7eKk


*/
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    private ConvoControls convoControls;

    public int characterWrapLimit;
    public RectTransform rectTransform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        //Creates an instance of the Input Action Controller to access mouse position
        convoControls = new ConvoControls();
        convoControls.Convo.Enable();
    }
    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isEditor)
        {
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        //Accesses Input from Input action instead of Input.mousePosition
        Vector2 position = convoControls.Convo.MousePosition.ReadValue<Vector2>();

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
