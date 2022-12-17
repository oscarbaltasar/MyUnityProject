using System.Collections;
using UnityEngine;

public class MusicManager: MonoBehaviour
{
    public AudioSource mainSource, secondarySource, leftSource, rightSource, frontSource;

    public AudioClip introClip,
        cinematicClip,
        welcomeClip,
        activateSenseClip,
        finishedSenseClip,
        passTutorialClip,
        tutorialClip,
        narrationClip;
    void Start()
    {
        ((IntroductionManager)IntroductionManager.Instance).OnIntroStart += StartIntroMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnCinematicStart += StartCinematicMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnWelcomeStart += StartWelcomeMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnActivateSenses += StartActivateSensesMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnPassTutorial += StartPassTutorialMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnInitTutorial += StartInitTutorialMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnInitNarration += StartNarrationMusic;
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.ActivateSenses);
    }


    void StartIntroMusic()
    {
        frontSource.PlayOneShot(cinematicClip); 
    }

    void StartCinematicMusic()
    {
        
    }

    void StartWelcomeMusic()
    {
        
    }

    void StartActivateSensesMusic()
    {
        StartCoroutine("LoadLeftSense");
    }

    IEnumerator LoadLeftSense()
    {
        leftSource.PlayOneShot(activateSenseClip);
        yield return new WaitUntil(() => !leftSource.isPlaying);
        StartCoroutine("LoadSucessLeftSense");
    }

    IEnumerator LoadSucessLeftSense()
    {
        leftSource.PlayOneShot(finishedSenseClip);
        yield return new WaitUntil(() => !leftSource.isPlaying);
        StartCoroutine("LoadRightSense");
    }

    IEnumerator LoadRightSense()
    {
        rightSource.PlayOneShot(activateSenseClip);
        yield return new WaitUntil(() => !rightSource.isPlaying);
        StartCoroutine("LoadSuccessRightSense");
    }

    IEnumerator LoadSuccessRightSense()
    {
        rightSource.PlayOneShot(finishedSenseClip);
        yield return new WaitUntil(() => !rightSource.isPlaying);
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.Intro);
    }

    void StartPassTutorialMusic()
    {
        
    }

    void StartInitTutorialMusic()
    {
        
    }

    void StartNarrationMusic()
    {
        
    }
}
