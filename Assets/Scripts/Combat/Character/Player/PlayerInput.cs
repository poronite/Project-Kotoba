using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public char GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return '←';
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            return '□';
        }
        else if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.Return))
            {
                if (Input.inputString.Length == 1)
                {
                    char key = Input.inputString.ToLower().ToCharArray()[0];

                    if (IsAllowedInput(key))
                    {
                        return key;
                    }
                }
                
            }
        }

        return '×';
    }


    private bool IsAllowedInput(char key)
    {
        return char.IsLetter(key);
    }
}
