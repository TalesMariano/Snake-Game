using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestObject 
{
    public int id;
    public Type type;






    public enum Type
    {
        TestObjectChildOne,
        TestObjectChildTwo
    }

}
[System.Serializable]
public class TestObjectChildOne : TestObject
{
    public string name;
}

[System.Serializable]
public class TestObjectChildTwo : TestObject
{
    public float num;
}
