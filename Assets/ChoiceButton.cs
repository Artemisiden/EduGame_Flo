using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceButton : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> current;
    public List<GameObject> next;
    public float duration;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerManager.Instance.buttonClicked = true;
        foreach(GameObject anim in current)
        {
            anim.SetActive(false);
        }
        foreach(GameObject anim in next)
        {
            anim.SetActive(true);
        }
        PlayerManager.Instance.buttonClicked = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerManager.Instance.buttonClicked = false;
        if(duration>0)
        {
            foreach(GameObject anim in current)
            {
                DelayManager.Instance.DeactiveWithDelay(anim, duration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
