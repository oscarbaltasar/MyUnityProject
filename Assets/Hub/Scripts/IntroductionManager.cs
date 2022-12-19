
public enum ENUM_STEPS
{
    Intro,
    Cinematic,
    Welcome,
    ActivateSenses,
    Tutorial,
    PassTutorial,
    InitTutorial,
    InitNarration,
    InterruptAction,
    ContinueAction,
    PauseAction
} 
public class IntroductionManager : Singleton
{

    public delegate void OnStart();
    
    private ENUM_STEPS currentAction, lastAction;
    
    public event OnStart OnIntroStart;
    public event OnStart OnCinematicStart;
    public event OnStart OnWelcomeStart;
    public event OnStart OnTutorialStart;
    public event OnStart OnPassTutorial;
    public event OnStart OnActivateSenses;
    public event OnStart OnInitTutorial;
    public event OnStart OnInitNarration;
    public event OnStart OnContinueAction;
    public event OnStart OnPauseAction;


    public void InitAction(ENUM_STEPS action)
    {
        lastAction = currentAction;
        currentAction = action;
        switch (action)
        {
            case ENUM_STEPS.Intro:
                OnIntroStart?.Invoke();
                break;
            case ENUM_STEPS.Cinematic:
                OnCinematicStart?.Invoke();
                break;
            case ENUM_STEPS.Welcome:
                OnWelcomeStart?.Invoke();
                break;
            case ENUM_STEPS.ActivateSenses:
                OnActivateSenses?.Invoke();
                break;
            case ENUM_STEPS.Tutorial:
                OnTutorialStart?.Invoke();
                break;
            case ENUM_STEPS.PassTutorial:
                OnPassTutorial?.Invoke();
                break;
            case ENUM_STEPS.InitTutorial:
                OnInitTutorial?.Invoke();
                break;
            case ENUM_STEPS.InitNarration:
                OnInitNarration?.Invoke();
                break;
            case ENUM_STEPS.InterruptAction:
                InterruptAction();
                break;
            case ENUM_STEPS.ContinueAction:
                OnContinueAction?.Invoke();
                break;
            case ENUM_STEPS.PauseAction:
                OnPauseAction?.Invoke();
                break;
        }   
    }

    private void InterruptAction()
    {
        InitAction(lastAction);
    }
    
}