using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject mainMenu;
    public GameObject flip;
    public TabGroup tab;
    public void OnPointerClick(PointerEventData eventData)
    {
        tab.selectedTab = null;
        tab.ResetTabs();
        tab.Update();
        flip.SetActive(true);
        DelayManager.Instance.ActiveWithDelay(mainMenu, 1.2f);
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
