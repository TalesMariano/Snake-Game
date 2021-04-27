using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEstFood : MonoBehaviour
{
    public TestTimeBlock timeBlock;
    [TextArea(3,10)]
    public string json;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeBlock = new TestTimeBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("To Json")]
    void Jossos()
    {
        json = JsonUtility.ToJson(timeBlock, true);
    }



}
