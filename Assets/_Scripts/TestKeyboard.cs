using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKeyboard : MonoBehaviour
{
    public KeyCode key1;
    public KeyCode key2;


    Dictionary<KeyCode, int> dictionary = new Dictionary<KeyCode, int>()
    {
        {KeyCode.Alpha1, 10},
        {KeyCode.Q, 11},
        {KeyCode.A, 12},
        {KeyCode.Z, 13},
        {KeyCode.Alpha2, 20},
        {KeyCode.W, 21},
        {KeyCode.S, 22},
        {KeyCode.X, 23},
        {KeyCode.Alpha3, 30},
        {KeyCode.E, 31},
        {KeyCode.D, 32},
        {KeyCode.C, 33},
        {KeyCode.Alpha4, 40},
        {KeyCode.R, 41},
        {KeyCode.F, 42},
        {KeyCode.V, 43},
        {KeyCode.Alpha5, 50},
        {KeyCode.T, 51},
        {KeyCode.G, 52},
        {KeyCode.B, 53},
        {KeyCode.Alpha6, 60},
        {KeyCode.Y, 61},
        {KeyCode.H, 62},
        {KeyCode.N, 63},
        {KeyCode.Alpha7, 70},
        {KeyCode.U, 11},
        {KeyCode.J, 12},
        {KeyCode.M, 13},
        {KeyCode.Alpha8, 80},
        {KeyCode.I, 81},
        {KeyCode.K, 82},
        {KeyCode.Alpha9, 90},
        {KeyCode.O, 91},
        {KeyCode.L, 92},
        {KeyCode.Alpha0, 100},
        {KeyCode.P, 101}
    };

    enum TestKey
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<KeyCode, int> entry in dictionary)
        {
            if (Input.GetKey(entry.Key))
            {
                if (key1 == entry.Key)
                    key2 = entry.Key;
                else
                    key1 = entry.Key;

            }
        }

        /*
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                //your code here
                key = vKey;

            }
        }*/
    }
}
