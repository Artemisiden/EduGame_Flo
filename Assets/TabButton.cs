using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public SpriteRenderer render;
    public Sprite tabIdle;
    public Sprite tabActive;
    public GameObject page;
    public GameObject flip;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(this.name == "StartButton")
        {
            tabGroup.selectedTab = render.GetComponent<TabButton>();
        }
        else
        {
            tabGroup.selectedTab = this;
        }
        tabGroup.ResetTabs();
        this.render.sprite = tabActive;
        this.render.sortingOrder = 3;
        flip.SetActive(true);
        DelayManager.Instance.ActiveWithDelay(page,1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.ResetTabs();
        if(tabGroup.selectedTab == null || tabGroup.selectedTab != this)
        {
            this.render.sprite = tabIdle;
            this.render.sortingOrder = 0;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tabGroup.Subscribe(this);
        //this.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
