using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject door_1;
    private GameObject door_2;
    private GameObject obstacles;
    private TextMeshProUGUI quest_1_text;
    private TextMeshProUGUI quest_2_text;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        door_1 = GameObject.Find("Door_1");
        door_2 = GameObject.Find("Door_2");
        obstacles = GameObject.Find("Obstacles");
        quest_1_text = GameObject.Find("Quest_1 Text").GetComponent<TextMeshProUGUI>();
        quest_2_text = GameObject.Find("Quest_2 Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name)
        {
            case "Step_1":
                door_1.SetActive(false);
                break;

            case "Step_2":
                gameManager.completedQuests++;
                door_2.SetActive(false);
                quest_1_text.text = "Take quest: 1/1";
                quest_1_text.color = Color.green;
                break;

            case "Step_3":
                if (!door_2.activeSelf)
                {
                    door_2.SetActive(true);
                }
                break;

            case "Step_4":
                gameManager.completedQuests++;
                quest_2_text.text = "Complete quest: 1/1";
                quest_2_text.color = Color.green;
                obstacles.SetActive(false);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (gameObject.name)
        {
            case "Step_1":
                door_1.SetActive(true);
                break;
        }
    }
}
