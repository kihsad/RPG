using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IClickable

{
    int MyCount
    {
        get;
    }

    Image MyIcon
    {
        get;
        set;
    }

}
