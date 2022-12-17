
public enum ENUM_STEPS
{
    Intro,
    Cinematic,
    Welcome,
    ActivateSenses,
    PassTutorial,
    InitTutorial,
    InitNarration,
    InterruptAction
} 
public class IntroductionManager : Singleton
{

    public delegate void OnStart();
    
    private ENUM_STEPS currentAction, lastAction;
    
    public event OnStart OnIntroStart;
    public event OnStart OnCinematicStart;
    public event OnStart OnWelcomeStart;
    public event OnStart OnPassTutorial;
    public event OnStart OnActivateSenses;
    public event OnStart OnInitTutorial;
    public event OnStart OnInitNarration;


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
        }   
    }

    private void InterruptAction()
    {
        InitAction(lastAction);
    }
    
}