using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float gravityDecreaseAmount = 0.1f; // مقدار کاهش جاذبه

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"🔄 برخورد ثبت شد با: {other.gameObject.name}");

        if (other.CompareTag("Player"))
        {
            GravityController gravityController = other.GetComponent<GravityController>();
            if (gravityController != null)
            {
                gravityController.DecreaseGravity(0.1f);
                Debug.Log($"⚡ برخورد با دشمن! مقدار جدید جاذبه: {gravityController.GetGravityScale()}");
            }
            else
            {
                Debug.LogError("🚨 GravityController یافت نشد! بررسی کنید که این اسکریپت روی بازیکن قرار دارد.");
            }

            Destroy(gameObject);
        }
    }

}
