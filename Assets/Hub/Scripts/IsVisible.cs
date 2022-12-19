using UnityEngine;


public class IsVisible : MonoBehaviour
{
    Renderer m_Renderer;

    private enum render
    {
        Render,
        NotRender,
        IsAdvicing,
        InitialState
    };

    private render stateRender = render.InitialState;

    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            if (stateRender == render.IsAdvicing)
            {
                ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.ContinueAction);
            }
            stateRender = render.Render;
        }
        else
        {
            if (stateRender != render.IsAdvicing)
            {
                stateRender = render.IsAdvicing;
                ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.PauseAction);
            }
        }
    }
}