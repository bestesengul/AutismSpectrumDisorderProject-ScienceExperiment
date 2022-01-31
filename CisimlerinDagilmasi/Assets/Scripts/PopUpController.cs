using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpController : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField] GameObject[] popUps;
    [SerializeField] GameObject ClickController;

    [Space]

    // --------- Static olmayanlarin public degiskenlerin sayisal degerini Inspector'da degistirmeyin ---------
    [Header("Watchers - Do not change values")]
    public float waitTime = 10f; // iki mesaj arasi bekleme suresi
    public float timer = 10f; // iki mesaj arasi gecen sure
    public static int  score = 0; // Asil Skor
    public int[] scoresTmp;// Skorlama icin temp value tasiyan array
    public int scoresTmpIndex = 0;
    

    [Space]

    [Header("Materials")]
    [SerializeField] GameObject deepPlateNohut;
    [SerializeField] GameObject deepPlateSusam;
    [SerializeField] GameObject deepPlateMercimek;
    [SerializeField] GameObject deepPlateBezelye;
    [SerializeField] GameObject tenisTopu;

    [Space]

    [Header("Buttons")]
    [SerializeField] GameObject buttonNohut;
    [SerializeField] GameObject buttonSusam;
    [SerializeField] GameObject buttonMercimek;
    [SerializeField] GameObject buttonBezelye;
    [SerializeField] GameObject buttonTenisTopu;

    [Space]

    [SerializeField] GameObject buttonKaristir;

    [Space]
    
    [Header("End-Game Panels")]
    [SerializeField] GameObject winWindow;
    [SerializeField] GameObject loseWindow;
    #endregion

    #region Private Variables
    private int popUpIndex;
    private List<int> Tasks = new List<int> { 2, 3, 4, 5, 7, 9, 10, 11, 12, 13, 15 };
    private AudioSource popUpAudioSource;
    private int controlAudio = 0;
    bool isChangedText = false;
    #endregion


    void Update()
    {
        #region Yonergeler arasi gecis kontrolu
        timer += Time.deltaTime;
        for (int i = 0; i < popUps.Length; i++)
        {
            if (timer > waitTime)
            {
                if (i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                    popUpAudioSource = popUps[i].GetComponent<AudioSource>();

                    if (controlAudio == 0)
                    {
                        popUpAudioSource.PlayOneShot(popUpAudioSource.clip);
                        controlAudio++;
                    }
                    if (Tasks.Contains(i))
                        timer = 0f;
                }

                else
                    popUps[i].SetActive(false);
            }
        }
        #endregion

        scoresTmp = new int[Tasks.Count];

        #region Tum yonergeler
        switch (popUpIndex)
        {
            case 0: // merhaba mesaji
                if (Input.GetMouseButtonDown(0))
                {
                    NextMessagePrep();
                }
                Debug.Log("Mesaj1");
                break;

            case 1: // tanitma baslangici mesaji
                if (Input.GetMouseButtonDown(0))
                    NextMessagePrep();
                Debug.Log("Mesaj2");
                break;

            case 2: // nohut
                if (buttonNohut.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonNohut.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj3");
                break;

            case 3: // susam
                if (buttonSusam.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonSusam.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj4");
                break;

            case 4: // mercimek
                if (buttonMercimek.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonMercimek.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj5");
                break;

            case 5: // bezelye
                if (buttonBezelye.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonBezelye.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj6");
                break;

            case 6: // tenis topu tanima baslangici mesaji
                if (Input.GetMouseButtonDown(0))
                    NextMessagePrep();
                Debug.Log("Mesaj7");
                break;

            case 7: // tenis topu
                if (buttonTenisTopu.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonTenisTopu.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj8");
                break;

            case 8: // dokulme baslangici mesaji
                if (Input.GetMouseButtonDown(0))
                    NextMessagePrep();
                Debug.Log("Mesaj9");
                break;

            case 9: // nohut - dokulme
                if (deepPlateNohut.GetComponent<Dokulme>().touch)
                {
                    AddScore(deepPlateNohut.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj10");
                break;

            case 10: // susam - dokulme
                if (deepPlateSusam.GetComponent<Dokulme>().touch)
                {
                    AddScore(deepPlateSusam.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj11");
                break;

            case 11: // mercimek - dokulme
                if (deepPlateMercimek.GetComponent<Dokulme>().touch)
                {
                    AddScore(deepPlateMercimek.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj12");
                break;

            case 12: // bezelye - dokulme
                if (deepPlateBezelye.GetComponent<Dokulme>().touch)
                {
                    AddScore(deepPlateBezelye.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj13");
                break;

            case 13: // tenis topu - surukleme
                if (tenisTopu.GetComponentInChildren<DragDrop>().isDragging)
                {
                    AddScore(tenisTopu.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj14");
                break;

            case 14: // karistirma baslangici mesaji
                if (Input.GetMouseButtonDown(0))
                    NextMessagePrep();
                Debug.Log("Mesaj15");
                break;

            case 15: // karistirma
                if (buttonKaristir.GetComponent<HandleButton>().isButtonPressed)
                {
                    AddScore(buttonKaristir.name);
                    NextMessagePrep();
                }
                Debug.Log("Mesaj16");
                break;

            case 16: // karistirma sonucu ve bitis
                if (Input.GetMouseButtonDown(0))
                    NextMessagePrep();
                Debug.Log("Mesaj17");
                break;
            #endregion

        #region Deney sonunda cikacak panellerin kontrolu
            default:
                StartCoroutine(Wait(score, Tasks.Count));
                Debug.Log("Hata! Yanlis yere bastin");
                break;
        }

       

    }


    IEnumerator Wait(int Score, int TaskNumber)
    {
        bool isWin = Score == TaskNumber;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1.0f; // GameController'daki LoadScene'nin duzgun calismasi icin

        if (isWin || !isChangedText)
            winWindow.SetActive(true);
      
    }
        #endregion

    void AddScore(string materialName)
    {
        if (scoresTmp[scoresTmpIndex] == 0 && ClickController.GetComponent<ClickController>().clickedObject.name == materialName)
        {
            score++;
            scoresTmp[scoresTmpIndex]++;
            // scoresTmp array'in bir sonraki mesajda yeni elemanla (degeri 0 olan) kiyaslanmasi icin
            scoresTmpIndex++;
        }
    }

    void NextMessagePrep()
    {
        popUpIndex++;
        controlAudio = 0;
    }

}