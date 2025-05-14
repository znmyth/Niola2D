using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"🔄 برخورد ثبت شد با: {other.gameObject.name}");

        // بررسی اینکه آیا شیء بازیکن است
        if (other.GetComponent<PlayerController2D>() != null)
        {
            Debug.Log("✅ بازیکن وارد در خروج شد! رفتن به مرحله بعد...");
            SceneManager.LoadScene("level2");
        }
    }
}
