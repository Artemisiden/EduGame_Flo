using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ArrowButton : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> prev;
    public List<GameObject> next;
    public GameObject flip;
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach(GameObject obj in prev)
        {
            if(obj!=null)
            {
                obj.SetActive(false);
            }
        }

        if (flip != null)
        {
            flip.SetActive(true);
        }

        foreach(GameObject obj in next)
        {
            if(obj!=null)
            {
                DelayManager.Instance.ActiveWithDelay(obj, 1.2f);
            }
        }
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
