using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour
{
    public int buttonIndex;

    private Button button;
    private ButtonHandler[] siblingButtons;
    private MenuScript menuScript;

    private void Start()
    {
        // Get the Button component
        button = GetComponent<Button>();

        // Add a listener for button clicks
        button.onClick.AddListener(OnClick);

        // Get sibling buttons
        siblingButtons = transform.parent.GetComponentsInChildren<ButtonHandler>();

        // Get the MenuScript component
        menuScript = FindObjectOfType<MenuScript>();
    }

    private void OnClick()
    {
        if (buttonIndex == 9)
        {
            // Randomize and click a sibling button
            List<ButtonHandler> validButtons = new List<ButtonHandler>();

            // Find all valid siblings
            foreach (ButtonHandler siblingButton in siblingButtons)
            {
                if (siblingButton.buttonIndex != 9)
                {
                    validButtons.Add(siblingButton);
                }
            }

            // Randomly select a sibling to click
            int randomIndex = Random.Range(0, validButtons.Count);
            ButtonHandler randomButton = validButtons[randomIndex];
            randomButton.ClickButton();

            // Disable the clicked sibling button
            randomButton.DisableButton();
        }
        else
        {
            // Disable the clicked button
            DisableButton();

            // Enable sibling buttons
            foreach (ButtonHandler siblingButton in siblingButtons)
            {
                if (siblingButton != this && siblingButton.buttonIndex != 9)
                {
                    siblingButton.EnableButton();
                }
            }
        }

        // Get the parent MenuScript component in the scene
        MenuScript parentMenu = GetComponentInParent<MenuScript>();

        // If it is not the index 9 button, save the button index in MenuScript
        if (buttonIndex != 9)
        {
            parentMenu.SetSelectedButton(buttonIndex);
        }

        // Print the button index
        Debug.Log("Button Index: " + buttonIndex);
    }

    private void DisableButton()
    {
        // Disable the button
        button.interactable = false;
    }

    private void EnableButton()
    {
        // Enable the button
        button.interactable = true;
    }

    public void ClickButton()
    {
        // Simulate clicking the button
        button.onClick.Invoke();
    }
}




/*

Made by : Rey M. Oronos, Jr.
Project : 

*/