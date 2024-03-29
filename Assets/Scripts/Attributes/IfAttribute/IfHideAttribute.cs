﻿using UnityEngine;
using System;

//Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class IfHideAttribute : PropertyAttribute
{
    public string ConditionalSourceField = "";
    public string ConditionalSourceField2 = "";
    public string[] ConditionalSourceFields = new string[] { };
    public bool[] ConditionalSourceFieldInverseBools = new bool[] { };
    public bool HideInInspector = false;
    public bool Inverse = false;
    public bool UseOrLogic = false;

    public bool InverseCondition1 = false;
    public bool InverseCondition2 = false;


	// Use this for initialization
    public IfHideAttribute(string conditionalSourceField)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = true;
        this.Inverse = false;
    }

    public IfHideAttribute(string conditionalSourceField, bool hideInInspector)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
        this.Inverse = false;
    }

    public IfHideAttribute(string conditionalSourceField, bool hideInInspector, bool inverse)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
        this.Inverse = inverse;
    }

    public IfHideAttribute(bool hideInInspector = false)
    {
        this.ConditionalSourceField = "";
        this.HideInInspector = hideInInspector;
        this.Inverse = false;
    }

    public IfHideAttribute(string[] conditionalSourceFields,bool[] conditionalSourceFieldInverseBools, bool hideInInspector, bool inverse)
    {
        this.ConditionalSourceFields = conditionalSourceFields;
        this.ConditionalSourceFieldInverseBools = conditionalSourceFieldInverseBools;
        this.HideInInspector = hideInInspector;
        this.Inverse = inverse;
    }

    public IfHideAttribute(string[] conditionalSourceFields, bool hideInInspector, bool inverse)
    {
        this.ConditionalSourceFields = conditionalSourceFields;        
        this.HideInInspector = hideInInspector;
        this.Inverse = inverse;
    }

}



