using UnityEngine;

public class EmoteWheelController : MonoBehaviour
{
    public GameObject emoteWheel;  // Assign the Emote Wheel UI GameObject in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            emoteWheel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            emoteWheel.SetActive(false);
        }
    }
}
