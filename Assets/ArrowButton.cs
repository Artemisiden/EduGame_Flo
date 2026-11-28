using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ArrowButton : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> prev;
    public string toActivate;
    public List<GameObject> next;
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach(GameObject obj in prev)
        {
            if(obj!=null)
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in SceneManager.GetSceneByName("Base").GetRootGameObjects())
        {
            if(obj.name == toActivate)
            {
                obj.SetActive(true);
                return;
            }
            else
            {
                Transform child = obj.transform.Find("Pages");
                {
                    if(child != null)
                    {
                        Transform grandChild = child.transform.Find(toActivate);
                        if(grandChild != null)
                        {
                            grandChild.gameObject.SetActive(true);
                            return;
                        }
                    }
                }
            }
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
