using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button RightButton, LeftButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        RightButton.onClick.AddListener(TaskOnClick);
        LeftButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Connecter.instance.Connect();
    }
}
