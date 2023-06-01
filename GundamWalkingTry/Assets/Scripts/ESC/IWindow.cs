using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindow 
{

    bool active { get; }
    public void Escape();
   
}
