using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBeforeDeath
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns> If continues after this</returns>
    bool DoBeforeDeath();
}
