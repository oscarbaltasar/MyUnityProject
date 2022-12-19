using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.XR.Interaction.Toolkit;

public class Hoop : MonoBehaviour {
	
	//particlesystem visible in inspector
	public ParticleSystem effect;
	public GameObject scoreText;
	public GameObject positionAnimation;

	public int score;
	private GameManager gameManager;
	private void Start()
	{
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		score = gameManager.score;
    }
    void OnTriggerEnter(Collider collider){
		//add 1 point to the main basketball script
		score++;
		gameManager.score = score;
        scoreText.GetComponent<TMP_Text>().text = score + "";

        //instantiate effect in the hoop
        Vector3 position = new Vector3(positionAnimation.transform.position.x, positionAnimation.transform.position.y, positionAnimation.transform.position.z);
		Instantiate(effect, position, Quaternion.identity);
        if (collider.tag == "Mina")
		{
			StartCoroutine(DeleteAfterDelay(collider));
		}
	}

    private IEnumerator DeleteAfterDelay(Collider collider)
    {
		collider.gameObject.GetComponent<Mina>().contadorOn = false;
        yield return new WaitForSeconds(0.5f);
        SendHaptics();
        collider.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);
        collider.gameObject.SetActive(false);
    }

    public void SendHaptics()
    {
        XRBaseController leftHand = (XRBaseController)GameObject.Find("LeftHand Controller").GetComponent<XRBaseController>();
        leftHand.SendHapticImpulse(0.7f, 0.5f);
        XRBaseController rightHand = (XRBaseController)GameObject.Find("RightHand Controller").GetComponent<XRBaseController>();
        rightHand.SendHapticImpulse(0.7f, 0.5f);
    }
}
