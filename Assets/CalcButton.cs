using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalcButton : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text text;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (text.text.ToCharArray().Length <6)
        {
            text.text += gameObject.name;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
