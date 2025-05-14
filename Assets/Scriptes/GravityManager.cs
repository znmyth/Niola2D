using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] private FloatingObject[] floatingObjects;
    private float currentGravity = 0.1f; // مقدار اولیه جاذبه بازیکن
    [SerializeField] private float gravityStep = 0.1f;

    private Rigidbody2D playerRb;
    private UIManager uiManager;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
            playerRb.gravityScale = currentGravity; // مقدار اولیه جاذبه بازیکن
        }

        uiManager = FindObjectOfType<UIManager>(); // پیدا کردن UIManager

        if (uiManager != null)
        {
            uiManager.UpdateEnergyBar(currentGravity); // مقدار اولیه تنظیم شود
        }
        else
        {
            Debug.LogError("UIManager یافت نشد! مطمئن شوید که این اسکریپت در صحنه قرار دارد.");
        }
    }

    public void OnEnergyCollected()
    {
        if (currentGravity < 1f) 
        {
            currentGravity = Mathf.Clamp(currentGravity + gravityStep, 0f, 1f);
            Debug.Log($"✅ انرژی جمع شد! مقدار جاذبه جدید: {currentGravity}");

            UpdateFloatingObjects();
            UpdatePlayerGravity();
            uiManager.UpdateEnergyBar(currentGravity); // مقدار جدید در نوار نمایش داده می‌شود
        }
    }

    public void OnEnemyHit()
    {
        if (currentGravity > 0f)
        {
            currentGravity = Mathf.Clamp(currentGravity - gravityStep, 0f, 1f);
            Debug.Log($"⚡ برخورد با دشمن! مقدار جاذبه جدید: {currentGravity}");

            UpdateFloatingObjects();
            UpdatePlayerGravity();
            uiManager.UpdateEnergyBar(currentGravity); // مقدار جدید در نوار نمایش داده می‌شود
        }
    }

    private void UpdateFloatingObjects()
    {
        if (floatingObjects == null || floatingObjects.Length == 0)
        {
            Debug.LogWarning("🚨 لیست `floatingObjects` خالی است! بررسی کنید.");
            return;
        }

        foreach (FloatingObject obj in floatingObjects)
        {
            if (obj != null)
            {
                obj.AdjustFloatingHeight(currentGravity);
            }
            else
            {
                Debug.LogWarning("🚨 یکی از اشیا معلق مقدار `null` دارد!");
            }
        }
    }

    private void UpdatePlayerGravity()
    {
        if (playerRb != null)
        {
            playerRb.gravityScale = currentGravity; // مقدار جاذبه بازیکن تنظیم می‌شود
        }
    }
}
