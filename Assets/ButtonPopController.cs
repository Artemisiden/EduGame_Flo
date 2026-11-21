using System.Collections.Generic;
using UnityEngine;

public class ButtonPopController : MonoBehaviour
{
    public List<GameObject> target;
    public float delay;
    public float barSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject button in target)
        {
            if(button.name == "Cycle")
            {
                DelayManager.Instance.ActiveWithDelay(button, 7);
            }
            else if (button.name == "Glass")
            {
                DelayManager.Instance.ActiveWithDelay(button, 16);
            }
            else
            {
                button.SetActive(false);
                DelayManager.Instance.ActiveWithDelay(button, delay);
                if(button.name == "Bar")
                {
                    button.GetComponent<Animator>().speed = barSpeed;
                }
            }
        }
        PlayerManager.Instance.buttonClicked = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
