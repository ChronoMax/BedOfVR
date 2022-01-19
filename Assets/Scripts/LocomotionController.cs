using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay, leftGrabRay;
    public InputHelpers.Button teleportationActivationButton;
    public float activationTreshhold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (leftTeleportRay)
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
        if (!CheckIfActivated(leftGrabRay))
        {
            leftGrabRay.gameObject.SetActive(true);
        }
        else
        {
            leftGrabRay.gameObject.SetActive(false);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportationActivationButton, out bool isActivated, activationTreshhold);
        return isActivated;
    }
}
