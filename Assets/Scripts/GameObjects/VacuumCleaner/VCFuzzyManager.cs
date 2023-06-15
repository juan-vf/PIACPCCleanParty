using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCFuzzyManager : MonoBehaviour
{
    
    private VCController vCController;
    //Battery fuzzy
    private float MBfull = 0f;
    private float MBHalf= 0f;
    private float MBEmpty = 0f;
    //Storage Fuzzy
    private float MSfull = 0f;
    private float MSHalf= 0f;
    private float MSEmpty = 0f;

    private float gradreLowBattery = 0f;
    private  float gradreDecomposed = 0f;
    private  float gradreBHalf = 0f;

    private void Start()
    {
        vCController = GetComponent<VCController>();
    }
    private void Update()
    {
        //entrada/s
        float BatteryPercentaje = vCController.getBattery;

        float StoragePercentaje = vCController.getStorage;
        // Debug.Log(BatteryPercentaje);

        //fuzzificacion
        MBEmpty = MembershipFunctions.InverseGradeF(BatteryPercentaje, 0f, 45f);
        MBHalf = MembershipFunctions.TrapezoidF(BatteryPercentaje, 30f, 50f, 60f, 80f);
        MBfull = MembershipFunctions.GradeF(BatteryPercentaje, 75f, 100f);
        // string n = string.Format("para completo:{0}, medio:{1}, low:{2}", MBfull, MBHalf, MBEmpty);
        // Debug.Log(n);
        
        MSEmpty = MembershipFunctions.InverseGradeF(BatteryPercentaje, 0f, 45f);
        MSHalf = MembershipFunctions.TrapezoidF(BatteryPercentaje, 30f, 50f, 60f, 80f);
        MSfull = MembershipFunctions.GradeF(BatteryPercentaje, 75f, 100f);
        // string b = string.Format("para completo:{0}, medio:{1}, low:{2}", MSfull, MSHalf, MSEmpty);
        // Debug.Log(b);

        //fuzzi rules
        gradreLowBattery = 0f;
        gradreDecomposed = 0f;
        gradreBHalf= 0f;

        gradreLowBattery = OperatorFunctions.AND(MBEmpty, OperatorFunctions.OR(MSHalf, MSEmpty));
        gradreDecomposed = OperatorFunctions.AND(MBEmpty, MSfull);
        gradreBHalf = OperatorFunctions.AND(MBHalf, OperatorFunctions.OR(MSHalf, MSEmpty));

        // if(gradreLowBattery > gradreDecomposed){
            //estado bateria baja

        // }else if(gradreDecomposed > gradreLowBattery){
            //estado descompuesto
        // }

        //bateriaBaja grade empty

        //Estado roto

    }

    //DEFUZZIFICATION
    public bool LowBattery{
        get{return gradreLowBattery > gradreDecomposed && gradreLowBattery > gradreBHalf;}
    }
    public bool DecomposedState{
        get{return gradreDecomposed > gradreLowBattery && gradreDecomposed > gradreBHalf;}
    }
    public bool HalfBattery{
        get{return gradreBHalf > gradreLowBattery && gradreBHalf > gradreDecomposed;}
    }




}
