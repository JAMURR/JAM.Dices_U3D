﻿using UnityEngine;

public class Table : MonoBehaviour
{
    public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;

    protected virtual void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerSwipe += OnFingerSwipe;
        //Lean.Touch.LeanTouch.OnFingerHeldDown += OnFingerHeldDown;
    }

    protected virtual void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
        //Lean.Touch.LeanTouch.OnFingerHeldDown -= OnFingerHeldDown;
    }

    public void OnFingerHeldDown(Lean.Touch.LeanFinger finger)
    {
        DiceManager.I.Reset();
    }

    public void OnFingerSwipe(Lean.Touch.LeanFinger finger)
    {
        // Raycast information
        var ray = finger.GetStartRay();
        var hit = default(RaycastHit);

        // Was this finger pressed down on a collider?
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true) {
            // Was that collider this one?
            if (hit.collider.gameObject == gameObject) {
                DiceManager.I.OnSwipe(finger);

            }
        }
    }
}