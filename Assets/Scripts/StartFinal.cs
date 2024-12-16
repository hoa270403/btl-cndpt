using UnityEngine;

public class StartShootingTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra nếu người chơi chạm vào
        {
            // Tìm kẻ địch và gọi phương thức StartShooting
            EnemyShooting enemyShooting = FindObjectOfType<EnemyShooting>();
            if (enemyShooting != null)
            {
                enemyShooting.StartShooting(); // Bắt đầu bắn
            }
            Destroy(gameObject); // Xóa đối tượng "start" sau khi người chơi chạm vào (tùy chọn)
        }
    }
}
