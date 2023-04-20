using System.Threading.Tasks;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManagement.instance.ChangeScene(Scenes.LEVEL1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
