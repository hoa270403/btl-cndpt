using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;      // Prefab của viên đạn
    public Transform firePoint;          // Điểm phát bắn
    public float bulletSpeed = 20f;      // Tốc độ của viên đạn
    public float shootingInterval = 2f;  // Thời gian giữa các lần bắn
    public bool facingRight = false;     // Kẻ địch bắt đầu quay mặt về bên trái (người chơi ở bên trái)

    private Transform player;            // Tham chiếu tới vị trí của người chơi
    private float nextTimeToShoot = 0f;
    private bool canShoot = false;       // Biến kiểm soát trạng thái bắn

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Tìm đối tượng người chơi qua tag
    }

    void Update()
    {
        FlipTowardsPlayer();  // Kiểm tra và lật hướng kẻ địch nếu cần

        if (canShoot && Time.time >= nextTimeToShoot) // Kiểm tra có được phép bắn không
        {
            ShootAtPlayer();
            nextTimeToShoot = Time.time + shootingInterval;
        }
    }

    void ShootAtPlayer()
    {
        if (player != null)
        {
            // Tính toán hướng bắn về phía người chơi
            Vector2 direction = (player.position - firePoint.position).normalized;

            // Tạo viên đạn
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Gán script BulletMovement để điều khiển viên đạn
            BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
            bulletScript.SetDirection(direction, bulletSpeed);  // Thiết lập hướng và tốc độ cho viên đạn
        }
    }

    // Hàm để lật hướng kẻ địch về phía người chơi
    void FlipTowardsPlayer()
    {
        if (player != null)
        {
            // Kiểm tra xem người chơi đang ở phía nào
            if (player.position.x > transform.position.x && !facingRight)
            {
                // Người chơi ở bên phải, lật kẻ địch sang phải
                Flip();
            }
            else if (player.position.x < transform.position.x && facingRight)
            {
                // Người chơi ở bên trái, lật kẻ địch sang trái
                Flip();
            }
        }
    }

    // Hàm lật hướng kẻ địch
    void Flip()
    {
        facingRight = !facingRight;  // Đảo ngược trạng thái quay mặt của kẻ địch
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  // Đảo ngược trục X để lật hình ảnh
        transform.localScale = theScale;  // Áp dụng sự thay đổi
    }

    // Hàm được gọi khi người chơi chạm vào đối tượng "start"
    public void StartShooting()
    {
        canShoot = true; // Cho phép bắn
    }
}
