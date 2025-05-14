using UnityEngine;

public class ExitGateManager : MonoBehaviour
{
    public GameObject exitGate; // شیء دروازه خروج

    public void CheckExitGate(float frictionEnergy)
    {
        if (frictionEnergy >= 1f)
        {
            exitGate.SetActive(true); // نمایش دروازه خروج
        }
        else
        {
            exitGate.SetActive(false); // مخفی کردن دروازه خروج
        }
    }
}
