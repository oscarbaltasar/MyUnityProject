using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;

public class Hoop : MonoBehaviour {
	
	//particlesystem visible in inspector
	public ParticleSystem effect;
	public GameObject scoreText;

	private int score = 0;

	void OnTriggerEnter(Collider collider){
		//add 1 point to the main basketball script
		score++;
        scoreText.GetComponent<TMP_Text>().text = score + "";

        //instantiate effect in the hoop
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.85f);
		Instantiate(effect, position, Quaternion.identity);
        if (collider.tag == "Mina")
		{
			collider.gameObject.SetActive(false);
		}
	}
}
