using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    [SerializeField]
    private Image[] _optionImageSelected;

    [SerializeField]
    private Image[] _optionImageUnselected;

    private Image _selectedImage;

    private bool xAxisInUse = false;
    private bool selectionAxisInUse = false;
    

    private int _index = 0;
    private int menuOp = 0;

    private void Start()
    {
        _selectedImage = _optionImageSelected[0];
        HighlightText();
    }

    private void Update()
    {
        checkAxisCommands("Horizontal", ref xAxisInUse);
        checkAxisCommands("Jump", ref selectionAxisInUse);
    }


    //generic command check list, scanning all command axes at once
    //feed it the axis and bool that controls it's "KeyDown" status
    private void checkAxisCommands(string pAxisName, ref bool pAxisToggle)
    {
        if (Input.GetAxisRaw(pAxisName) != 0) //if we've pressed button
        {
            if (pAxisToggle == false) //if the key is not pressed down
            {
                switch (pAxisName)
                {
                    case "Horizontal":
                        xAxisCommands();
                        break;
                    case "Jump":
                        selectionAxisCommands();
                        break;
                }
                pAxisToggle = true; //key is now 'down'
            }
        }
        //key has now been lifted up
        if (Input.GetAxisRaw(pAxisName) == 0)
        {
            pAxisToggle = false;
        }
    }

    //input manager commands using horizontal keys
    private void xAxisCommands()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)//left
        {/*
            if (_index == 0)
            {
                _index = _optionImageSelected.Length - 1;
            }
            else
            {
                _index--;
            }
            _selectedImage = _optionImageSelected[_index];*/
            menuOp = 0;
            HighlightText();
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)//right
        {/*
            if (_index == _optionImageSelected.Length - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }
            _selectedImage = _optionImageSelected[_index];*/
            menuOp = 1;
            HighlightText();
        }

    }

    private void HighlightText()
    {
        Debug.Log("selectedImage: " + _selectedImage);

        if (menuOp == 0)
        {
            _optionImageUnselected[0].enabled = false;
            _optionImageSelected[0].enabled = true;
            _optionImageUnselected[1].enabled = true;
            _optionImageSelected[1].enabled = false;
        }

        if (menuOp == 1)
        {
            _optionImageUnselected[0].enabled = true;
            _optionImageSelected[0].enabled = false;
            _optionImageUnselected[1].enabled = false;
            _optionImageSelected[1].enabled = true;
        }



        /*

        for (int i = 0; i < _optionImageSelected.Length; i++)
        {
            //_optionImageSelected[i].enabled = false;
            _optionImageUnselected[i].enabled = true;
            if (_optionImageSelected[i] == _selectedImage)
            {
                _optionImageUnselected[i].enabled = false;
                _optionImageSelected[i].enabled = true;
            }
            else
            {
                _optionImageSelected[i].enabled = false;
                _optionImageUnselected[i].enabled = true;
            }
        }*/
    }

    //increment the menu depth of our cursor
    //each increment is a further submenu down
    private void selectionAxisCommands()
    {
        print("selectionAxisCommands");
        string name = "";
        for (int i = 0; i < _optionImageSelected.Length - 1; i++)
        {
            //name += _optionImageSelected[i].text;
        }

        if (_selectedImage == _optionImageSelected[0])
        {
            PlayerPrefs.SetString("Replay", "True");
            SceneManager.LoadScene("Level_001");
        }
        else
        {
            SceneManager.LoadScene("Menu4");
        }

    }
}
