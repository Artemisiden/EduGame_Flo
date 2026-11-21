using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 targetOffset = new Vector3(0.57f, 6.91f, 0);
    public float speed = 1f;
    public float targetTime;
    public GameObject previous;
    private Vector3 startPos;
    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(previous.activeInHierarchy)
        {
            targetTime+= Time.deltaTime;
        }
        time+=Time.deltaTime;
        if(time > targetTime)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos + targetOffset, speed * Time.deltaTime);   
        }
    }
}
