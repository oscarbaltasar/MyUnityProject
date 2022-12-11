using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class Hoop : MonoBehaviour {
	
	//particlesystem visible in inspector
	public ParticleSystem effect;
	public GameObject scoreText;
	public GameObject positionAnimation;

	private int score = 0;

	void OnTriggerEnter(Collider collider){
		//add 1 point to the main basketball script
		score++;
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

        yield return new WaitForSeconds(0.5f);
        collider.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);
        collider.gameObject.SetActive(false);
    }
}
