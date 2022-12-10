using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GunGlow : MonoBehaviour
{
    [SerializeField] private InputActionReference activarAtaque;
    //[SerializeField] private XRRayInteractor interactorActivarAtaque;
    private Color customColor = new Color(1f, 1f, 1f, 1.0f);
    public Renderer cubeRenderer;


    public void OnEnable()
    {
        cubeRenderer.material.color = customColor;
        activarAtaque.action.started += CambiarColor;
    }

    public void OnDisable()
    {
        activarAtaque.action.started -= CambiarColor;
    }


    private void CambiarColor(InputAction.CallbackContext obj)
    {
            //interactorActivarAtaque.enabled = !interactorActivarAtaque.enabled;
            customColor.r -= 0.1f;
            customColor.g -= 0.1f;
            customColor.b -= 0.1f;
            cubeRenderer.material.color = customColor;
        
    }
}
