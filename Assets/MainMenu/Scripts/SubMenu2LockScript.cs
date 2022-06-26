using UnityEngine;
using UnityEngine.UI;
public class SubMenu2LockScript : MonoBehaviour
{
    [SerializeField] private GameObject Locked0;
    [SerializeField] private GameObject Locked1;
    [SerializeField] private GameObject Locked2;
    [SerializeField] private Button GameButton1;
    [SerializeField] private Button GameButton2;
    [SerializeField] private Button GameButton3;
    public Sprite NotPlayedMat;
    public Sprite PlayedMat;
    //a script to check player progression on japanesse world and lock the levels and mark them accoring to it
    void Start()
    {
        if (Locked0.activeSelf)
        {
            if (PlayerPrefs.GetInt("japaneseDoodleJump") == 1)
            {
                Locked0.SetActive(false);
            }
        }
        if (Locked1.activeSelf)
        {
            if (PlayerPrefs.GetInt("japanesePlatform") == 1)
            {
                Locked1.SetActive(false);
                GameButton1.GetComponent<Image>().sprite = PlayedMat;
            }
        }
        if (Locked2.activeSelf)
        {
            if (PlayerPrefs.GetInt("japaneseMaze") == 1)
            {
                Locked2.SetActive(false);
                GameButton2.GetComponent<Image>().sprite = PlayedMat;
            }
        }
        if (PlayerPrefs.GetInt("JapaneseRunner") == 1)
        {
            GameButton3.GetComponent<Image>().sprite = PlayedMat;
        }
    }
}
