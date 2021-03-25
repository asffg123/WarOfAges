using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [UnityEngine.SerializeField]
    private Text textObject;

    public void UpdateText(uint currentHp, uint maxHp)
    {
        textObject.text = $"HP: { currentHp } / { maxHp }";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
