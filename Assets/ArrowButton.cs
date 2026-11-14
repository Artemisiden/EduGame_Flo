using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowButton : MonoBehaviour, IPointerClickHandler
{
    public TabButton tab;
    public GameObject flip;
    public void OnPointerClick(PointerEventData eventData)
    {
        tab.tabGroup.selectedTab = tab;
        tab.tabGroup.ResetTabs();
        flip.SetActive(true);
        DelayManager.Instance.ActiveWithDelay(tab.page, 1.2f);
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
