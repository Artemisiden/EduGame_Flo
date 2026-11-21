using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerSpace : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text text;
    public void OnPointerClick(PointerEventData eventData)
    {
        text.text = "";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
