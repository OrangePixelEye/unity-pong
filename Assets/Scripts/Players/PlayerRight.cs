using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : Players
{
    public override void HandleInput()
    {
        int move = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move = -1;
        }
        MoveBar(move);
    }
}
