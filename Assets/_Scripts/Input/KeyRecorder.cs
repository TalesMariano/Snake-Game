using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRecorder : MonoBehaviour
{
    public GameManager gameManager;






    // Internal Vars
    bool heldOneSecond;
    float timerHold = 0;

    KeyCode key1;
    KeyCode key2;

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


    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (!Input.GetKey(key1))
            {
                // Get Key 1
                foreach (KeyValuePair<KeyCode, int> entry in dictionary)
                {
                    if (entry.Key != key2 && Input.GetKey(entry.Key))
                    {
                        key1 = entry.Key;
                    }
                }
            }

            if (!Input.GetKey(key2))
            {
                // Get Key 2
                foreach (KeyValuePair<KeyCode, int> entry in dictionary)
                {
                    if (entry.Key != key1 && Input.GetKeyDown(entry.Key))
                    {
                        key2 = entry.Key;
                    }
                }
            }
        }

        // Start Game
        if (Input.GetKeyDown(KeyCode.Return))
            gameManager.StartGame();

        // If both record key are pressed, start timer
        if (Input.GetKey(key1) && Input.GetKey(key2))
        {
            timerHold += Time.deltaTime;

            if (timerHold > 1 && !heldOneSecond)
            {
                heldOneSecond = true;

                gameManager.AddNewPlayer(OrderKeyCodes(key1, key2));

            }

        }


        // Reset Timer
        if (Input.GetKeyUp(key1) || Input.GetKeyUp(key2))
        {
            timerHold = 0;
            heldOneSecond = false;
        }

    }


    /// <summary>
    /// Order two keys to left and right based on keyboard bosition
    /// 
    /// </summary>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public KeyCode[] OrderKeyCodes(KeyCode key1, KeyCode key2)
    {
        int value1, value2;

        dictionary.TryGetValue(key1, out value1);
        dictionary.TryGetValue(key2, out value2);

        if (value1 < value2)
            return new KeyCode[] { key1, key2 };
        else
            return new KeyCode[] { key2, key1 };
    }
}
