using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCommands : MonoBehaviour
{
    [Commmand]
    public void Help() { 
    
    }

    [Commmand(typeof(int), typeof(int), typeof(int))]
    public void TestParams(int x, int y, int z) {
    
    }
}
