using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager: MonoBehaviour
{
    public Text introText1, introText2, introText3, introText4;

    public VideoPlayer videoPlayer;

    public VideoClip videoclipCinematic;
    void Start()
    {
        ((IntroductionManager)IntroductionManager.Instance).OnIntroStart += StartIntroUI;
        ((IntroductionManager)IntroductionManager.Instance).OnCinematicStart += StartCinematicUI;
        ((IntroductionManager)IntroductionManager.Instance).OnWelcomeStart += StartWelcomeUI;
        ((IntroductionManager)IntroductionManager.Instance).OnActivateSenses += StartActivateSensesUI;
        ((IntroductionManager)IntroductionManager.Instance).OnPassTutorial += StartPassTutorialUI;
        ((IntroductionManager)IntroductionManager.Instance).OnInitTutorial += StartInitTutorialUI;
        ((IntroductionManager)IntroductionManager.Instance).OnInitNarration += StartNarrationUI;

        introText1.enabled = false;
        introText2.enabled = false;
        introText3.enabled = false;
        introText4.enabled = false;
    }


    void StartIntroUI()
    {
        StartCoroutine("Intro1");
    }
    
    IEnumerator Intro1()
    {
        introText1.enabled = true;
        yield return new WaitForSeconds(3);
        introText1.enabled = false;
        StartCoroutine("Intro2");
    }
    
    IEnumerator Intro2()
    {
        introText2.enabled = true;
        yield return new WaitForSeconds(4);
        introText2.enabled = false;
        StartCoroutine("Intro3");
    }
    
    IEnumerator Intro3()
    {
        introText3.enabled = true;
        yield return new WaitForSeconds(4);
        introText3.enabled = false;
        StartCoroutine("Intro4");
    }
    
    IEnumerator Intro4()
    {
        introText4.enabled = true;
        yield return new WaitForSeconds(3);
        introText4.enabled = false;
    }

    void StartCinematicUI()
    {
        StartCoroutine("LoadVideoCinematicCowntdown");
    }

    IEnumerator LoadVideoCinematicCowntdown()
    {
        yield return new WaitForSeconds(5);

        videoPlayer.clip = videoclipCinematic;
        videoPlayer.Play();
    }

    void StartWelcomeUI()
    {
        videoPlayer.enabled = false;
    }

    void StartActivateSensesUI()
    {
    }
    
    void StartPassTutorialUI()
    {
        
    }

    void StartInitTutorialUI()
    {
        
    }

    void StartNarrationUI()
    {
        
    }
}
