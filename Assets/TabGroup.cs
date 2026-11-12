using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public List<GameObject> pages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject page in pages)
        {
            if(page.activeInHierarchy)
            {
                foreach(TabButton tab in tabButtons)
                {
                    //tab.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
        //button.GetComponent<Collider2D>().enabled = false;
    }
    public void ResetTabs()
    {
        if(selectedTab != null)
        {
            foreach(TabButton button in tabButtons)
            {
                if(button == selectedTab)
                {
                    button.render.sprite = button.tabActive;
                    button.render.sortingOrder = 3;
                }
                else
                {
                    button.render.sprite = button.tabIdle;
                    button.render.sortingOrder = 0;
                    button.page.SetActive(false);
                }
            }
        }
    }
}
