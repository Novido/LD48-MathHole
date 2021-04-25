using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject TargetObject;
    [HideInInspector]
    public TextMeshProUGUI TargetText;
    public int target;

    public GameObject CurrentObject;
    [HideInInspector]
    public TextMeshProUGUI CurrentText;
    public float currentValue;

    public GameObject NrOfMovesObject;
    [HideInInspector]
    public TextMeshProUGUI NrOfMovesText;
    public int numberOfMoves;

    public GameObject WinPanel;
    public GameObject LosePanel;

    [Space]

    public GameObject ButtonPrefab;
    private static int maxButtons = 7;

    [Space]

    private AudioSource audioSource;
    public Slider volumeSlider;


    // Start is called before the first frame update
    void Start()
    {
        // Generate a target between 100 and 999
        target = Random.Range(100, 999);
        TargetText = TargetObject.GetComponent<TextMeshProUGUI>();
        TargetText.text = "Target: " + target.ToString();

        // Current Value
        CurrentText = CurrentObject.GetComponent<TextMeshProUGUI>();
        CurrentText.text = "Current Value: " + currentValue.ToString();

        // Number of moves
        numberOfMoves = 0;
        NrOfMovesText = NrOfMovesObject.GetComponent<TextMeshProUGUI>();
        NrOfMovesText.text = "Moves: " + numberOfMoves;

        // Instantiate buttons 
        // If it's the first round, make them all add to current value
        SpawnButtons();

        // Play music
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        // Update text
        TargetText.text = "Target: " + target.ToString();
        CurrentText.text = "Current Value: " + currentValue.ToString();
        NrOfMovesText.text = "Moves: " + numberOfMoves;

        // Check if current value is equal to the target
        if (currentValue == target)
        {
            Debug.Log("You win!");
            WinPanel.SetActive(true);
        }

        // Check if current value is float
        // if so, plater fails. 
        if (currentValue % 1 > 0)
        { 
            Debug.Log("You have failed");
            LosePanel.SetActive(true);
        }
        else if(currentValue < 0)
        {
            Debug.Log("You have failed!");
            LosePanel.SetActive(true);
        }

        // update volume
        audioSource.volume = volumeSlider.value;

        
    }

    public void SpawnButtons()
    {
        for (int i = 0; i < maxButtons; i++)
        {
            Debug.Log("New button!");
            var newButton = Instantiate(ButtonPrefab);
            newButton.transform.SetParent(GameObject.Find("Buttons Panel").transform);

        }
    }

    public void ClearBoard()
    {
        //Debug.Log("Destroying buttons");

        GameObject[] buttons;

        buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach (var item in buttons)
        {
            Destroy(item);
        }

        
    }
}
