using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManuManager 
{
   public static void GotoMenu()
    {
       
            Object.Instantiate(Resources.Load("PauseMenu"));
        
    }
}
