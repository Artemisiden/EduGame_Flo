using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public List<GameObject> objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
