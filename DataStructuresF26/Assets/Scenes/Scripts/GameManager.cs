using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    //Variables
    public TextMeshProUGUI stacktext;

    public TextMeshProUGUI queuetext;

    public InputActionReference interactstack;

    public InputActionReference interactqueue;

    private string[] colors = new string[7] {"Orange", "blue", "red", "chartruse", "green", "black","indigo"};

    //Make a list that is empty and will hold strings
    private List<string> colorList=new List<string>();

    //Make a stack of strings
    //STACKS are LIFO (Last In First Out)
    private Stack<string> colorStack = new Stack<string>();
    private Stack<string> colorStackfromList = new Stack<string>();

    //Make a queue of strings
    //Queues are FIFO (First In First Out)
    private Queue<string> colorQueue = new Queue<string>();

    private Queue<string> colorQueuefromList = new Queue<string>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Add the strings from the array to the list
        colorList.AddRange(colors);

        //Add the strings from the array to our stacks
        //For loop created from an array 
        for (int i = 0; i < colors.Length; i++)
        {
            //Add the string from the location of the array that matches our number
            colorStack.Push(colors[i]);
        }
        //Print the number of strings in my stack
        Debug.Log(colorStack.Count);

        //Add the strings from the list to the stack
        //For loop from a list
        for (int i = 0; i < colorList.Count; i++)
        {
            //Add the strings to the stack by location or count number
            colorStackfromList.Push(colorList[i]);
        }

        //Add the strings from the array to the queue
        // For each string in our array add it to the queue
        foreach (string s in colors)
        {
            colorQueue.Enqueue(s);
        }

        //Add all strings from the list to the queue
        //For each string in the list add it to the queue
        foreach (string s in colorList)
        {
            colorQueuefromList.Enqueue(s);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Make the texts say the top position of stack and queue
        if (interactstack.action.WasPressedThisFrame() && colorStack.Count > 0 )
        {
            stacktext.text = colorStack.Pop();
        }else if(interactqueue.action.WasPressedThisFrame() && colorQueue.Count > 0)
        {
            queuetext.text = colorQueue.Dequeue();
        }
    }
}
