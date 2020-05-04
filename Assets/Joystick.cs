using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform thisTransform;
    [SerializeField]
    private Transform parentTransform;

    private Vector3 startPos;

    private Vector3 parentRectSize;
    private Vector3 thisRectSize;

    private Movement playerMovement;


    private float MovementDeltaX;
    private float MovementDeltaY;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = Vector3.zero;
        float deltaX = eventData.position.x - startPos.x;
        float deltaY = eventData.position.y - startPos.y;

        MovementDeltaX = deltaX;
        MovementDeltaY = deltaY;
        
        deltaX = Mathf.Clamp(deltaX, -parentRectSize.x + thisRectSize.x, parentRectSize.y - thisRectSize.x);
        deltaY = Mathf.Clamp(deltaY, -parentRectSize.y + thisRectSize.y, parentRectSize.y - thisRectSize.y);

        newPos.x = deltaX;
        newPos.y = deltaY;

        newPos = newPos + startPos;

        thisTransform.position = newPos;


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        thisTransform.localPosition = Vector3.zero;
        MovementDeltaX = 0f;
        MovementDeltaY = 0f;
    }

    void Start()
    {
        startPos = thisTransform.position;

        parentRectSize = parentTransform.GetComponent<RectTransform>().rect.size;
        thisRectSize = thisTransform.GetComponent<RectTransform>().rect.size;

        
    }

    void Update()
    {
        if (playerMovement == null)
        {
            playerMovement = LocalPlayer.INSTANCE.Player.GetComponent<Movement>();
        }
        playerMovement.MovePlayer(MovementDeltaX * 0.00625f, 0f, MovementDeltaY * 0.00625f);
    }



}
