using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuOver : MonoBehaviour
{
    public void ChoiLai(){
        SceneManager.LoadScene(4);
    }
    public void VeManHinhChinh(){
        SceneManager.LoadScene(0);
    }
    public void Thoat(){
        Application.Quit();
    }
}
