using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour
{
    private MenuScript menuScript;
    private ButtonHandler[] siblingButtons;
    private Button button;
    public int buttonIndex;

 

    private void Start() {
        // Get the MenuScript component
        menuScript = FindObjectOfType<MenuScript>();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        // Get sibling buttons
        siblingButtons = transform.parent.GetComponentsInChildren<ButtonHandler>();
    } //-- Start()

    private void OnClick() {
        // Get the parent MenuScript component in the scene
        MenuScript parentMenu = GetComponentInParent<MenuScript>();

        // Button Index 9 functions as a randomizer
        if (buttonIndex == 9) {
            // Randomize and click a sibling button
            List<ButtonHandler> validButtons = new List<ButtonHandler>();

            // Find all valid siblings
            foreach (ButtonHandler siblingButton in siblingButtons) {
                if (siblingButton.buttonIndex != 9) {
                    validButtons.Add(siblingButton);
                }
            }

            // Randomly select a sibling button
            int randomIndex = Random.Range(0, validButtons.Count);
            ButtonHandler randomButton = validButtons[randomIndex];
            randomButton.ClickButton();

            // Disable the clicked sibling button
            randomButton.DisableButton();
        } else {
            // Disable the clicked button
            DisableButton();

            // Enable sibling buttons
            foreach (ButtonHandler siblingButton in siblingButtons) {
                if (siblingButton != this && siblingButton.buttonIndex != 9) {
                    siblingButton.EnableButton();
                }
            }
        }

        // If it is not the index 9 button, save the button index in MenuScript
        if (buttonIndex != 9) {
            parentMenu.SetSelectedButton(buttonIndex);
        }
    } //-- OnClick()

    private void DisableButton() {
        // Disable the button
        button.interactable = false;
    }

    public void EnableButton() {
        // Enable the button
        button.interactable = true;
    }

    public void ClickButton() {
        // Simulate clicking the button
        button.onClick.Invoke();
    }
}



/*

Made by : Rey M. Oronos, Jr.
Project : 

*/