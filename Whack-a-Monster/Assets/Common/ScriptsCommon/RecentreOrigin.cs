using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class RecentreOrigin : MonoBehaviour
{
    public Transform target;
    private void Awake()
    {
        XROrigin xROrigin = GetComponent<XROrigin>();
        xROrigin.MoveCameraToWorldLocation(target.position);
        xROrigin.MatchOriginUpCameraForward(target.up, target.forward); 
    }
}
