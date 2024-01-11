using UnityEngine;
using UnityEngine.SceneManagement;

public class TangGiamAmLuong : MonoBehaviour
{
    public AudioSource audioSource;
    void KiemTra()
    {
        // Kiểm tra xem AudioSource có được gắn kết không
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Tăng âm lượng
    public void IncreaseVolume(float amount)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(audioSource.volume + amount);
        }
    }

    // Giảm âm lượng
    public void DecreaseVolume(float amount)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(audioSource.volume - amount);
        }
    }
}