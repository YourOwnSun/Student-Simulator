using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveCardInformation : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
    public Sprite artImage;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnMouse1Pressed += Current_OnMouse1Pressed;
    }

    private void Current_OnMouse1Pressed(object sender, GameEvents.OnMouse1PressedEventArgs e)
    {
        Debug.Log("Received information");
        nameText.text = e.name;
        descriptionText.text = e.description;
        transform.localScale = new Vector3(2, 2, 2);
    }

    public void CloseWindow() 
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
