using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
public class FinalBossIntro : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;  // Camera zoom vào người chơi
    public CinemachineVirtualCamera enemyCam;   // Camera zoom vào boss
    public TMP_Text dialogueText;                   // Văn bản hiển thị
    public string playerMessage = "Đã đến màn cuối,Bạn cần phải né tất cá các viên đạn của quái vậtvà thu thập hết số chuối để dành chiến thắng!";
    public string bossMessage = "Ngươi không dễ đánh bại ta đâu!";
    public Movement playerMovement;
    //public GameObject canvas;// Tham chiếu đến script Movement
    private bool isPlayerZoomed = true;
    private bool isBossZoomed = false;

    void Start()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = playerMessage;
        //canvas.SetActive(true);
        playerCam.Priority = 10;
        enemyCam.Priority = 5;

        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Vô hiệu hóa di chuyển của nhân vật
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerZoomed) // Chuột trái để zoom vào boss
        {
            ZoomToBoss();
        }
        else if (Input.GetMouseButtonDown(0) && isBossZoomed) // Chuột trái để bắt đầu trận đấu boss
        {
            StartBossFight();
        }
    }

    void ZoomToBoss()
    {
        
        playerCam.Priority = 5; // Giảm độ ưu tiên của camera người chơi
        enemyCam.Priority = 10; // Tăng độ ưu tiên của camera boss
        dialogueText.text = bossMessage;
        isPlayerZoomed = false;
        isBossZoomed = true;
    }

    void StartBossFight()
    {
        //canvas.SetActive(false);
        dialogueText.gameObject.SetActive(false);   // Ẩn hộp thoại
        playerCam.Priority = 10;  // Đặt lại camera người chơi với độ ưu tiên cao
        enemyCam.Priority = 5;    // Đặt lại camera boss với độ ưu tiên thấp
        isBossZoomed = false;     // Đặt cờ trạng thái

        if (playerMovement != null)
        {
            playerMovement.enabled = true; // Kích hoạt lại di chuyển của nhân vật
        }

        // Kích hoạt các hành vi trận đấu boss
    }
}
