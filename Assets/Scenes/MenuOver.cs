using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChoiLai(){
        SceneManager.LoadScene(1);
    }
    public void VeManHinhChinh(){
        SceneManager.LoadScene(2);
    }
    public void Thoat(){
        Application.Quit();
    }
}