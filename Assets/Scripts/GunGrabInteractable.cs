using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunGrabInteractable : XRGrabInteractable
{
    [SerializeField]
    private Transform _secondAttachTransform;

    protected override void Awake()
    {
        base.Awake();
        selectMode = InteractableSelectMode.Multiple;
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(this.interactorsSelecting.Count == 1)
        {
            base.ProcessInteractable(updatePhase);
        } else if (this.interactorsSelecting.Count == 2
            && XRInteractionUpdateOrder.UpdatePhase.Dynamic == updatePhase)
        {
            ProcessTwoHandGrab();
        }

    }

    private void ProcessTwoHandGrab()
    {
        Transform firstAttach = GetAttachTransform(null);
        Transform firstHand = interactorsSelecting[0].transform;
        Transform secondAttach = _secondAttachTransform;
        Transform secondHand = interactorsSelecting[0].transform;

        Vector3 directionBetweenHands = secondHand.position - firstHand.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionBetweenHands, firstHand.up);

        Vector3 worldDirectionFromHandleToBase = transform.position - firstAttach.position;
        Vector3 localDirectionFromHandleToBase = transform.InverseTransformDirection(worldDirectionFromHandleToBase);

        Vector3 targetPosition = firstHand.position + targetRotation * localDirectionFromHandleToBase;

        transform.SetPositionAndRotation(targetPosition, targetRotation);
    }
}
