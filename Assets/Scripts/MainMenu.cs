// Import các thư viện cần thiết cho Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Định nghĩa lớp MainMenu, kế thừa từ MonoBehaviour
public class MainMenu : MonoBehaviour
{
    // Hàm này được gọi khi người chơi nhấn vào nút "Play"
    public void PlayGame()
    {
        // Chuyển đến cảnh có build index là 1 (thường là level đầu tiên của trò chơi)
        SceneManager.LoadSceneAsync(1);
    }

    // Hàm này được gọi khi người chơi nhấn vào nút "Quit"
    public void QuitGame()
    {
        // Thoát ứng dụng
        Application.Quit();
    }
}
