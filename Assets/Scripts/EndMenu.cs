using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Định nghĩa lớp EndMenu, kế thừa từ MonoBehaviour
public class EndMenu : MonoBehaviour
{
    // Phương thức này được gọi khi người chơi chọn thoát game
    public void QuitGame()
    {
        // Thoát ứng dụng khi chạy dưới dạng build
        Application.Quit();
        // Lưu ý: Khi chạy trong Unity Editor, lệnh này sẽ không có tác dụng
    }

    // Phương thức này được gọi khi người chơi chọn chơi lại
    public void PlayAgain()
    {
        // Tải lại cảnh (scene) đầu tiên (cảnh có chỉ số 0) một cách bất đồng bộ
        SceneManager.LoadSceneAsync(0);
        // Lưu ý: Đảm bảo rằng cảnh đầu tiên đã được thêm vào Build Settings của Unity
    }
}
