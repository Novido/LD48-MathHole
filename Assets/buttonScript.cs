//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{

    // Create a list of possible values
    private List<int> PossibleNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 75, 100 };
    private List<string> PossibleOperators = new List<string> { "+", "-", "*", "/" }; 

    // Global Text component
    [HideInInspector]
    public Text textComponent;

    private GameManager gm;

    // Values to send
    int value;
    public string operatorText
    {
        get;
        set;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        textComponent = GetComponentInChildren<Text>();

        // Randomize an index value
        int NumberListCount = PossibleNumbers.Count;
        int index = Random.Range(0, NumberListCount);
        value = PossibleNumbers[index];
        string textNumber = value.ToString();

        if (gm.numberOfMoves < 1)
        {
            operatorText = PossibleOperators[0];
        }
        else
        {
            // Randomize an operator
            int OperatorListCount = PossibleOperators.Count;
            int i = Random.Range(0, OperatorListCount);
            operatorText = PossibleOperators[i];
        }

        textComponent.text = operatorText + " " + textNumber;
    }

    public void ButtonClick()
    {
        // Send value to GameManager
        switch(operatorText)
        {
            case "+":
                gm.currentValue += value;
                break;
            case "-":
                gm.currentValue -= value;
                break;
            case "*":
                gm.currentValue *= value;
                break;
            case "/":
                gm.currentValue /= value;
                break;
        }

        // Call clear board function
        gm.ClearBoard();

        // +1 Number of moves
        gm.numberOfMoves += 1;

        gm.SpawnButtons();
    }
}
