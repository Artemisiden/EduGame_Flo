using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalcDone : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text text;
    public float answer;
    private int clicks;
    public List<GameObject> prev;
    public List<GameObject> correct;
    public List<GameObject> close;
    public List<GameObject> wrong;
    public void OnPointerClick(PointerEventData eventData)
    {
        clicks+=1;
        foreach(GameObject anim in prev)
        {
            if(anim!=null)
            {
                    anim.SetActive(false);
            }
        }

        if (clicks<4)
        {
            if (answer>=1 && answer<=10)
            {
                if(answer>=2 && answer<=3)
                {
                    foreach(GameObject anim in correct)
                    {
                        if(anim!=null)
                        {
                            anim.SetActive(true);
                        }
                    }
                }
                else
                {
                    foreach(GameObject anim in close)
                    {
                        if(anim!=null)
                        {
                            anim.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                foreach(GameObject anim in wrong)
                    {
                        if(anim!=null)
                        {
                            anim.SetActive(true);
                        }
                    }
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clicks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(text.text!="")
        {
            answer = float.Parse(text.text);
        }
    }
}
