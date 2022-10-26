using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Question : MonoBehaviour
{
    public abstract void OnChoosingButton(int index);
    public abstract string ToStringAnswer();
}
