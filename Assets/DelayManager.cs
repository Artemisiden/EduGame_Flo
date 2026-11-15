using System;
using System.Collections;
using UnityEngine;

public class DelayManager : MonoBehaviour
{
    public static DelayManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActiveWithDelay(GameObject target, float delay)
    {
        StartCoroutine(ActivationRoutine(target,delay));
    }

    public void DeactiveWithDelay(GameObject target, float delay)
    {
        StartCoroutine(DeactivationRoutine(target,delay));
    }

    private IEnumerator ActivationRoutine(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(target != null)
        {
            target.SetActive(true);
        }
    }

    private IEnumerator DeactivationRoutine(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(target != null)
        {
            target.SetActive(false);
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
