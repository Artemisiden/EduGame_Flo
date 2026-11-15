using System.Collections.Generic;
using UnityEngine;

public class NextAnimation : MonoBehaviour
{
    public List<GameObject> next;

    private void OnDisable()
    {
        if(PlayerManager.Instance.buttonClicked == false)
        {
            if(next.Count>0)
            {
                foreach(GameObject anim in next)
                {
                    anim.SetActive(true);
                }
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
