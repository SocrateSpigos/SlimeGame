using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Crossroad : MonoBehaviour //this will serve as a 'reference index' - rather than assign public variables to
                                       //every script, when possible and convenient they will be drawn upon from this script
                                        //no functions here besides those strictly needed for the above. 
                                        //can't make the statics visible without some voodoo so two fields per thing - one visible, one static
{

    public FuelBar Fuel;
    public static FuelBar FuelBarManager;
    public BoneLookAt LookAt;
    public static BoneLookAt LookAtManager;
    public UiElements UI;
    public static UiElements UIManager;
    public BackpackManager backpack;
    public static BackpackManager backpackManager;
    public Material[] colorMaterials;
    public static Material[] mats;
    public CharMove movement;
    public static CharMove movementScript;
    public GoalManager goalManager;
    public static GoalManager goal;
    public GroundGen ground;
    public static GroundGen groundGen;
    public static float fuel;
    public float maxFuel;
    public static float mxFl;
    public float FuelMultiplier;
    public static float FuelMult;

    
    public static float score;
    public static bool multiplierFLag = true;

    private void Awake()                                //and here, the two sides merge
    {
        FuelBarManager = Fuel;
        LookAtManager = LookAt;
        UIManager = UI;
        backpackManager = backpack;
        mats = colorMaterials;
        movementScript = movement;
        goal = goalManager;
        groundGen = ground;
        mxFl = maxFuel;
        FuelMult = FuelMultiplier;
    }

    public void Update()
    {
      
    }

}
