using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> prev;
    public List<GameObject> next;
    public GameObject air;
    public Vector3 endPosition;
    public AudioSource audio;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.transform.position = endPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 65);
        foreach(GameObject obj in prev)
        {
            if(obj!=null)
            {
                obj.SetActive(false);
            }
        }
        foreach(GameObject obj in next)
        {
            if(obj!=null)
            {
                obj.SetActive(true);
            }
            if(obj.name == "Streams")
            {
                DelayManager.Instance.DeactiveWithDelay(obj, 1);
            }
        }
        air.transform.position = new Vector3(0, 2.48f, 0);
        DelayManager.Instance.DeactiveWithDelay(air, 0.6f);
        DelayManager.Instance.DeactiveWithDelay(this.gameObject, 1);
        audio.Play();
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
