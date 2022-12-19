using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTutorial : MonoBehaviour
{

    public void PassTutorial()
    {
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.PassTutorial);
    }
    
    public void InitTutorial()
    {
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.InitTutorial);
    }
}
