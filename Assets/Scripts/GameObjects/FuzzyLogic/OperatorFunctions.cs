using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OperatorFunctions
{
    public static float AND(float A, float B){
        return Mathf.Min(A, B);
    }
    public static float OR(float A, float B){
        return Mathf.Max(A, B);
    }
}
