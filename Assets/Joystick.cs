using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject parent;

    private bool dragging;

    private Vector3 centerPos;

    private Transform thisTransform;
    private Transform parentTransform;

    private Camera mainCamera;

    private Vector3 startPos;

    private Vector3 diff;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        thisTransform.position = eventData.position;
        diff = new Vector3(eventData.position.x, 0f, eventData.position.y) - new Vector3(startPos.x, 0f, startPos.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        thisTransform.position = centerPos;
        startPos = Vector3.zero;
    }

    void Start()
    {
        centerPos = gameObject.transform.position;
        thisTransform = gameObject.transform;
        parentTransform = parent.transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        Debug.Log(diff);
        LocalPlayer.INSTANCE.Player.GetComponent<Rigidbody>().AddForce(new Vector3(diff.x, 0f, diff.z) * Time.deltaTime);
    }

}
