using UnityEngine;
using UnityEngine.EventSystems;

public class WaterPour : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float tiltSensitivity = 0.2f;
    [SerializeField] private float maxTiltAngle = 25f;
    [SerializeField] private float returnSpeed = 10f;
    public AudioSource audio;
    public GameObject nextArrow;

    private float targetAngle = 0f;
    private bool isDragging = false;
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;

        targetAngle -= eventData.delta.x * tiltSensitivity;
        targetAngle = Mathf.Clamp(targetAngle, -maxTiltAngle, maxTiltAngle);
        audio.Play();
        nextArrow.SetActive(true);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        targetAngle = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentZ = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * returnSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, currentZ);
    }
}
