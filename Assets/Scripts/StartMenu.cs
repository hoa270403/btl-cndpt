using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Hàm này được gọi khi người chơi nhấn vào nút "Start Game"
    public void StartGame()
    {
        // Tải và chuyển đến cảnh (scene) tiếp theo trong danh sách build (build index + 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
