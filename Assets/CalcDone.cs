using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public List<GameObject> next;
    private bool isWrong = false;
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
                            clicks = 3;
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
                    if(clicks==3)
                    {
                        DelayManager.Instance.DeactiveWithDelay(anim, 1.68f);
                        isWrong = true;
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
        if (clicks == 3)
        {
            foreach(GameObject anim in next)
            {
                if(isWrong == true)
                {
                    if(anim.name == "2.5persen")
                    {
                        DelayManager.Instance.ActiveWithDelay(anim, 4.68f);
                        DelayManager.Instance.DeactiveWithDelay(anim, 14.68f);
                    }
                    else
                    {
                        DelayManager.Instance.ActiveWithDelay(anim, 1.68f);
                    }
                }
                else if(anim!=null)
                {
                    if(anim.name == "2.5persen")
                    {
                        DelayManager.Instance.ActiveWithDelay(anim, 6f);
                        DelayManager.Instance.DeactiveWithDelay(anim, 16f);
                    }
                    else
                    {
                        DelayManager.Instance.ActiveWithDelay(anim, 3f);
                    }
                }
            }
            foreach(GameObject anim in prev)
            {
                if(anim!=null)
                {
                    anim.SetActive(false);
                }
            }
            this.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
