using UnityEngine;

public class ExitDoorActivator : MonoBehaviour
{
    public GameObject exitDoorPrefab; // Prefab در خروج
    private GameObject exitDoorInstance;
    private bool doorSpawned = false;
    private GravityController gravityController;
    private Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            gravityController = player.GetComponent<GravityController>();
            playerTransform = player.transform; // ذخیره موقعیت بازیکن
        }
    }

    void Update()
    {
        if (gravityController != null)
        {
            float currentGravity = gravityController.GetGravityScale();

            if (!doorSpawned && currentGravity >= 1f)
            {
                SpawnExitDoor();
            }
            else if (doorSpawned && currentGravity < 1f)
            {
                HideExitDoor();
            }
        }
    }

    void SpawnExitDoor()
    {
        if (exitDoorInstance != null) return; // جلوگیری از ساخت مجدد دروازه خروج

        if (playerTransform != null)
        {
            Vector3 spawnPosition = playerTransform.position + new Vector3(10f, 0f, 0f); // نزدیک بازیکن
            exitDoorInstance = Instantiate(exitDoorPrefab, spawnPosition, Quaternion.identity);
            doorSpawned = true;
            Debug.Log($"✅ دروازه خروجی ظاهر شد! موقعیت: {spawnPosition}");
        }
    }

    void HideExitDoor()
    {
        if (exitDoorInstance != null)
        {
            Destroy(exitDoorInstance); // حذف دروازه خروج
            exitDoorInstance = null;
            doorSpawned = false;
            Debug.Log("🚫 دروازه خروجی ناپدید شد!");
        }
    }
}
