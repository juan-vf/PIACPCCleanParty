using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MembershipFunctions
{
    public static float GradeF(float valor, float x0, float x1){
        float membership = 0f;

        if(valor <= x0){
            membership = 0f;
        } else if(valor > x0 && valor < x1){
            membership = (valor / (x1 - x0)) - (x0 / (x1 - x0));
        }else if(valor >= x1){
            membership = 1f;
        }
        // Debug.Log(valor);
        return membership;
    }
    public static float InverseGradeF(float valor, float x0, float x1){
        float membership = 0f;
        if(valor <= x0){
            membership = 1f;
        } else if(valor > x0 && valor < x1){
            membership = (-valor / (x1 - x0)) + (x1 / (x1 - x0));
        }else if(valor >= x1){
            membership = 0f;
        }
        // Debug.Log(valor);
        return membership;
    }
    public static float TriangleF(
        float valor, float x0, float x1, float x2
    ){
        float membership = 0f;

        if(valor <= x0){
            membership = 0f;
        }else if((valor > x0) && (valor < x1)){
            membership = (valor / (x1 - x0)) - (x0 / (x1 - x0));
        }else if(valor == x1){
            membership = 1f;
        }else if((valor > x1) && (valor < x2)){
            membership = (-valor / (x2 - x1)) + (x2 / (x2 - x1));            
        }else if(valor >= x2){
            membership = 0f;
        }
        return membership;
    }
    public static float TrapezoidF(
        float valor, float x0, float x1, float x2, float x3
    ){
        float membership = 0f;
        if(valor <= x0){
            membership = 0f;
        }else if((valor > x0) && (valor < x1)){
            membership = (valor / (x1 - x0)) - (x0 / (x1 - x0));
        }else if((valor >= x1) && (valor <= x2)){
            membership = 1f;
        }else if((valor > x2) && (valor < x3)){
            membership = (-valor / (x3 - x2)) + (x3 / (x3 - x2));
        }else if(valor >= x3){
            membership = 0f;
        }
        // Debug.Log(valor);
        return membership;
    }
}
