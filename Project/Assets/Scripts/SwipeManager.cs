using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    //public static SwipeManager instance;

    ////Направление
    //public enum Direction { Left, Right, Up, Down };
    //bool[] swipe = new bool[4];

    //Vector2 startTouch;
    //Vector2 swipeDelta;
    //bool touchMoved;

    //const float SWIPE_THRESHOLD = 50;

    //public delegate void MoveDelegate(bool[] swipes);
    //public MoveDelegate MoveEvent;

    //public delegate void ClickDelegate(Vector2 touchPos);
    //public ClickDelegate ClickEvent;
    //Vector2 TouchPosition() { 
    //    return (Vector2)Input.mousePosition; 
    //}
    //bool TouchBegan() { 
    //    return Input.GetMouseButtonDown(0); 
    //}
    //bool TouchEnded() { 
    //    return Input.GetMouseButtonUp(0); 
    //}
    //bool GetTouch() { 
    //    return Input.GetMouseButton(0); 
    //}
    //private void Awake(){
    //    instance = this;
    //}
    //void Update()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject()) 
    //        return;

    //    if (TouchBegan())
    //    {
    //        startTouch = TouchPosition();
    //        touchMoved = true;
    //    }
    //    else if (TouchEnded() && touchMoved)
    //    {
    //        SendSwipe();
    //        touchMoved = false;
    //    }
    //    //Посчитать длину свайпа
    //    swipeDelta = Vector2.zero;
    //    if (touchMoved && GetTouch())
    //    {
    //        swipeDelta = TouchPosition() - startTouch;
    //    }
    //    //Был ли свайп
    //    if(swipeDelta.magnitude > SWIPE_THRESHOLD)
    //    {
    //        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
    //        {
    //            //лево-право
    //            swipe[(int)Direction.Left] = swipeDelta.x < 0;
    //            swipe[(int)Direction.Right] = swipeDelta.x > 0;
    //        }
    //        else
    //        {
    //            //верх-низ
    //            swipe[(int)Direction.Up] = swipeDelta.y < 0;
    //            swipe[(int)Direction.Down] = swipeDelta.y > 0;
    //        }
    //        SendSwipe();
    //    }
    //}

    //void SendSwipe()
    //{
    //    if (swipe[0] || swipe[1] || swipe[2] || swipe[3])
    //    {
    //        //print("L "+swipeDelta[0] +"|R "+ swipeDelta[1] +"|U "+ swipeDelta[2] +"|D "+ swipeDelta[3]);
    //        MoveEvent?.Invoke(swipe); //if (MoveEvent != null) MoveEvent(swipe);
    //    }
    //    else
    //    {
    //        //print("Click");
    //        ClickEvent?.Invoke(TouchPosition());
    //    }
    //    Reset();
    //}

    //void Reset()
    //{
    //    startTouch = swipeDelta = Vector2.zero;
    //    touchMoved = false;
    //    for (int i = 0; i < swipe.Length; i++)
    //        swipe[i] = false;
    //}
}
