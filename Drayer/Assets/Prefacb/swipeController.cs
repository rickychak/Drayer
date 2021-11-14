using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class swipeController : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    JoystickPlayerExample jpe;

    void Start()
    {
        jpe = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickPlayerExample>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
       
  
        jpe.Rotatation(eventData.delta.y, eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // Debug.Log("Mouse Up");
    }
}
/*
public class swipeController : MonoBehaviour
{

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public GameObject player;
    JoystickPlayerExample jpe;
    
    Touch touch;
    Vector2 touchPosition;
    Quaternion rotationY;
    public bool mouseUsed = true;
    float magnitude;


    public void OnPointerDown()
    {
        Debug.Log("ASD");
    }
    /*
    void Update()
    {
        if (!mouseUsed)
        {
            if (Input.touches.Length > 0)
            {
                Debug.Log("ASD");

                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    jpe.Rotatation(touch.deltaPosition.x, touch.deltaPosition.y);
                }
            }
        }
    }
   

} */