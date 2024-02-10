using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    [SerializeField] float swipeThreshold = 100f;
    [SerializeField] float tapThreshold = 20f;
    [SerializeField] float holdDuration = 0.5f;
    private float touchStartTime;
    private bool isHoldingTap = false;
    private bool hasDetectedSwipe = false;

    void Update()
    {
        DetectSwipe();
        if (!hasDetectedSwipe) {
            DetectTap();
            DetectTapAndHold();
        }
    }

    private void DetectSwipe() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
                hasDetectedSwipe = false;
            }

            if (touch.phase == TouchPhase.Ended) {
                fingerUpPosition = touch.position;

                if (IsVerticalSwipe() && IsSwipeDistanceMet()) {
                    if (fingerDownPosition.y - fingerUpPosition.y > 0) {
                        BroadcastMessage("LaneUp");
                    }
                    else {
                        BroadcastMessage("LaneDown");
                    }
                    hasDetectedSwipe = true;
                }

                if (IsHorizontalSwipe() && IsSwipeDistanceMet()) {
                    if (fingerDownPosition.x - fingerUpPosition.x > 0) {
                        Debug.Log("Swipe Left"); // if necessary
                    }
                    else {
                        BroadcastMessage("Throw_Projectile");
                    }
                    hasDetectedSwipe = true;
                }
            }
        }
    }

    private void DetectTap() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && touch.tapCount == 1 && touch.deltaTime < 0.2f && touch.deltaPosition.magnitude < tapThreshold) {
                BroadcastMessage("CallLeap");
            }
        }
    }

    private void DetectTapAndHold() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                touchStartTime = Time.time;
                isHoldingTap = false;
            }

            else if (touch.phase == TouchPhase.Ended) {
                if (isHoldingTap) {
                    BroadcastMessage("Duck_End");
                }
                isHoldingTap = false;
            }
        }

        float currentTime = Time.time;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && currentTime - touchStartTime > holdDuration) {
            isHoldingTap = true;
            BroadcastMessage("Duck_Start");           
        }
    }

    private bool IsVerticalSwipe() {
        return Mathf.Abs(fingerUpPosition.y - fingerDownPosition.y) > Mathf.Abs(fingerUpPosition.x - fingerDownPosition.x);
    }

    private bool IsHorizontalSwipe() {
        return Mathf.Abs(fingerUpPosition.y - fingerDownPosition.y) < Mathf.Abs(fingerUpPosition.x - fingerDownPosition.x);
    }

    private bool IsSwipeDistanceMet() {
        return Mathf.Abs(fingerUpPosition.x - fingerDownPosition.x) > swipeThreshold || Mathf.Abs(fingerUpPosition.y - fingerDownPosition.y) > swipeThreshold;
    }
}
