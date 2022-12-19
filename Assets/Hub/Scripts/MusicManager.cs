using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager: MonoBehaviour
{

    [Header("AudioSource Scene")] 
    public AudioSource mainSource;

    public AudioSource mikeSource;
    public AudioSource mikePauseSource;
    public AudioSource secondarySource;
    public AudioSource leftSource;
    public AudioSource rightSource;
    public AudioSource frontMainSource;
    public AudioSource frontSecondarySource;

    [Header("Intro")] 
    public AudioClip introClip;
    
    [Header("Cinematic")] 
    public AudioClip cinematicClip;
    public AudioClip cinematicVoiceClip;

    [Header("Welcome")] 
    public AudioClip welcomeClip1;
    public AudioClip welcomeClip2;
    public AudioClip welcomeClip3;
    public AudioClip welcomeClip4;
    public AudioClip welcomeClip5;

    [Header("Activate Senses")] 
    public AudioClip activateSenseClip1;
    public AudioClip activateSenseClip2;
    public AudioClip activateSenseClip3;
    public AudioClip activateSenseClip4;
    public AudioClip activateLoadSenseClip;
    public AudioClip activateSuccessSenseClip;

    [Header("Tutorial")] 
    public AudioClip passTutorialClip;
    public AudioClip initTutorialClip;
    public AudioClip tutorialClip;
    public AudioClip narrationClip;

    public AudioClip mikePauseClip;
    void Start()
    {
        ((IntroductionManager)IntroductionManager.Instance).OnIntroStart += StartIntroMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnCinematicStart += StartCinematicMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnWelcomeStart += StartWelcomeMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnActivateSenses += StartActivateSensesMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnTutorialStart += StartTutorialMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnPassTutorial += StartPassTutorialMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnInitTutorial += StartInitTutorialMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnInitNarration += StartNarrationMusic;
        ((IntroductionManager)IntroductionManager.Instance).OnPauseAction += PauseMike;
        ((IntroductionManager)IntroductionManager.Instance).OnContinueAction += ContinueMike;
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.Intro);
    }


    void StartIntroMusic()
    {
        StartCoroutine("LoadIntroMusic");
    }

    IEnumerator LoadIntroMusic()
    {
        frontMainSource.PlayOneShot(introClip);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.Cinematic);
    }

    void StartCinematicMusic()
    {
        StartCoroutine("LoadCinematicVoice");
    }

    IEnumerator LoadCinematicVoice()
    {
        frontMainSource.PlayOneShot(cinematicVoiceClip);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);

        StartCoroutine("LoadCinematicCountdown");
    }
    
    IEnumerator LoadCinematicCountdown()
    {
        frontSecondarySource.PlayOneShot(cinematicClip);
        yield return new WaitUntil(() => !frontSecondarySource.isPlaying);
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.Welcome);
    }

    void StartWelcomeMusic()
    {
        StartCoroutine("LoadWelcomeMusic1");
    }

    IEnumerator LoadWelcomeMusic1()
    {
        frontMainSource.PlayOneShot(welcomeClip1);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        StartCoroutine("LoadWelcomeMusic2");
    }
    
    IEnumerator LoadWelcomeMusic2()
    {
        frontMainSource.PlayOneShot(welcomeClip2);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        StartCoroutine("LoadWelcomeMusic3");
    }
    
    IEnumerator LoadWelcomeMusic3()
    {
        frontMainSource.PlayOneShot(welcomeClip3);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        StartCoroutine("LoadWelcomeMusic4");
    }
    
    IEnumerator LoadWelcomeMusic4()
    {
        frontMainSource.PlayOneShot(welcomeClip4);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        StartCoroutine("LoadWelcomeMusic5");
    }
    
    IEnumerator LoadWelcomeMusic5()
    {
        frontMainSource.PlayOneShot(welcomeClip5);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.ActivateSenses);
    }

    void StartActivateSensesMusic()
    {
        StartCoroutine("LoadLeftActivateSenseVoice");
    }

    IEnumerator LoadLeftActivateSenseVoice()
    {
        frontMainSource.PlayOneShot(activateSenseClip1);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        StartCoroutine("LoadLeftActivateSenseMusic");
    }

    IEnumerator LoadLeftActivateSenseMusic()
    {
        leftSource.PlayOneShot(activateLoadSenseClip);
        yield return new WaitUntil(() => !leftSource.isPlaying);
        StartCoroutine("SuccessLeftActivateSenseMusic");
    }
    
    IEnumerator SuccessLeftActivateSenseMusic()
    {
        leftSource.PlayOneShot(activateSuccessSenseClip);
        yield return new WaitUntil(() => !leftSource.isPlaying);
        StartCoroutine("LoadRightActivateSenseVoice");
    }
    IEnumerator LoadRightActivateSenseVoice()
    {
        frontMainSource.PlayOneShot(activateSenseClip2);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        StartCoroutine("LoadRightActivateSenseMusic");
    }

    IEnumerator LoadRightActivateSenseMusic()
    {
        rightSource.PlayOneShot(activateLoadSenseClip);
        yield return new WaitUntil(() => !rightSource.isPlaying);
        StartCoroutine("SuccessRightActivateSenseMusic");
    }
    
    IEnumerator SuccessRightActivateSenseMusic()
    {
        rightSource.PlayOneShot(activateSuccessSenseClip);
        yield return new WaitUntil(() => !rightSource.isPlaying);
        StartCoroutine("SuccessActivateSenseVoice");
    }
    
    IEnumerator SuccessActivateSenseVoice()
    {
        frontMainSource.PlayOneShot(activateSenseClip3);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        StartCoroutine("LoadActivateView");
    }
    
    IEnumerator LoadActivateView()
    {
        frontMainSource.PlayOneShot(activateSenseClip4);
        yield return new WaitUntil(() => !frontMainSource.isPlaying);
        
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.InitNarration);
    }

    void StartTutorialMusic()
    {
        mikeSource.PlayOneShot(tutorialClip);
    }

    void PauseMike()
    {
       mikeSource.Pause(); 
       mikePauseSource.PlayOneShot(mikePauseClip);
    }

    void ContinueMike()
    {
        StartCoroutine("LoadContinueMike");
    }

    IEnumerator LoadContinueMike()
    {
        yield return new WaitUntil(() => !mikePauseSource.isPlaying);
        
        mikeSource.UnPause();
    }

    void StartPassTutorialMusic()
    {
        StartCoroutine("LoadPassTutorial");
    }
    
    IEnumerator LoadPassTutorial()
    {
        mikeSource.Stop();
        mikeSource.PlayOneShot(passTutorialClip);
        yield return new WaitUntil(() => !mikeSource.isPlaying && !mikePauseSource.isPlaying);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }

    void StartInitTutorialMusic()
    {
        StartCoroutine("LoadInitTutorial");
    }
    
    IEnumerator LoadInitTutorial()
    {
        mikeSource.Stop();
        mikeSource.PlayOneShot(initTutorialClip);
        yield return new WaitUntil(() => !mikeSource.isPlaying && !mikePauseSource.isPlaying);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }

    void StartNarrationMusic()
    {
        mainSource.PlayOneShot(narrationClip);
        ((IntroductionManager)IntroductionManager.Instance).InitAction(ENUM_STEPS.Tutorial);
    }
}
