using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{

[SerializeField]
private int baseValue;
    private List<int> modifiers = new List<int>();


public int GetValue ()
{
    return baseValue;
}





}
