using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject currentPage;
    public TabGroup tabGroup;
    public TabButton tab;
    public GameObject flip;
    public void OnPointerClick(PointerEventData eventData)
    {
        currentPage.SetActive(false);
        tabGroup.selectedTab = tab;
        flip.SetActive(true);
        DelayManager.Instance.ActiveWithDelay(tab.page,1.2f);
        tabGroup.ResetTabs();
        foreach(TabButton tabs in tabGroup.tabButtons)
        {
            tabs.GetComponent<Collider2D>().enabled = true;
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
