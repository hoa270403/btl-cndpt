using UnityEngine;
using System.Collections; // Để sử dụng IEnumerator

public class BulletMovement : MonoBehaviour
{
    private Vector2 direction;           // Hướng di chuyển của viên đạn
    private float speed;                 // Tốc độ của viên đạn
    private Animator animator;           // Animator để điều khiển animation

    public float destroyDelay = 1.5f;   // Thời gian hủy viên đạn sau khi nổ

    public void SetDirection(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;
        animator = GetComponent<Animator>(); // Lấy component Animator
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng và tốc độ
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Đã va chạm với: " + other.gameObject.name);

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);  // Hủy viên đạn khi va chạm với tường
        }
        else if (other.CompareTag("Player"))
        {
            // Kích hoạt animation nổ
            ActivateExplosion();
        }
    }

    void ActivateExplosion()
    {
        if (animator != null)
        {
            // Dừng lại chuyển động của viên đạn
            speed = 0; // Ngừng viên đạn
            animator.SetTrigger("Explode"); // Gọi animation nổ
            StartCoroutine(DestroyAfterDelay(destroyDelay)); // Hủy viên đạn sau một khoảng thời gian
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);  // Hủy viên đạn sau khi animation hoàn tất
    }
}
