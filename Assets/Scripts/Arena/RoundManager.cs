using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RoundManager : MonoBehaviour
{
    public int initialValue = 0;
    public int valueGainedPerRound = 10;
    public List<GameObject> enemyList;
    public List<int> enemyValueList;
    public Transform spawnCorner1;
    public Transform spawnCorner2;

    public GameObject roundTextObject;

    private int currentValue;
    private int currentRound = 0;
    private TextMeshProUGUI roundText;

    public bool buttonPressed = false;

    void Start()
    {
        roundText = roundTextObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            if (buttonPressed)
            {
                currentValue = initialValue + currentRound * valueGainedPerRound;
                while (currentValue >= 0)
                {
                    int randomIndex;
                    int maxTries = 10;
                    do
                    {
                        maxTries--;
                        randomIndex = Random.Range(0, enemyValueList.Count);
                    } while (enemyValueList[randomIndex] < currentValue && maxTries > 0);
                    Debug.Log(randomIndex + " " + enemyValueList[randomIndex] + " " + currentValue);
                    GameObject newEnemy = Instantiate(enemyList[randomIndex]);
                    Vector3 newSpawnPosition = new Vector3(Random.Range(spawnCorner1.position.x, spawnCorner2.position.x), Random.Range(spawnCorner1.position.y, spawnCorner2.position.y), Random.Range(spawnCorner1.position.z, spawnCorner2.position.z));
                    Debug.Log(newSpawnPosition);
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(newSpawnPosition, out hit, 10.0f, NavMesh.AllAreas))
                    {
                        newEnemy.transform.position = hit.position;
                    }
                    newEnemy.SetActive(true);
                    currentValue -= enemyValueList[randomIndex];
                }
                currentRound++;
                roundText.text = (System.Convert.ToInt32(roundText.text) + 1).ToString();
                buttonPressed = false;
            }
        }
    }

    public void buttonPress()
    {
        buttonPressed = true;
    }
}
