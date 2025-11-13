using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Sc : MonoBehaviour
{
    public GameObject text_object_1 = null;
    Text text_1;
    public GameObject text_object_2 = null;
    Text text_2;

    public GameObject tutorialButton;
    public GameObject playNowButton;

    public int  textInterval = 10;
    int text1Tmr;
    int tutorialText1Tmr;
    int tutorialText2Tmr;
    int tutorialText3Tmr;
    int tutorialText4Tmr;
    int tutorialText5Tmr;
    int tutorialText6Tmr;
    int tutorialText7Tmr;
    int playNowTextTmr;

    GameObject shootingman;
    Shooting_Sc shootingman_Sc;

    public static int shot10Times; 

    public static int minShot; 
    public static int maxShot;

    public static int point3;
    public static int point2;
    public static int point1;
    public static int point0;

    // Start is called before the first frame update
    void Start()
    {
        text_1 = text_object_1.GetComponent<Text>();
        text_2 = text_object_2.GetComponent<Text>();

        text_1.fontSize = 15;
        text_2.fontSize = 15;
    }

    // Update is called once per frame
    void Update()
    {
        text1Create();
        tutorialText1Create();
        tutorialText2Create();
        tutorialText3Create();
        tutorialText4Create();
        tutorialText5Create();
        tutorialText6Create();
        tutorialText7Create();
        playNowTextCreate();
        textShotCount();
    }

    void text1Create()
    {
        if(GameManager_Sc.idx != 0){return;}

        string[] text1 = {"パ","チ","ン","コ","屋","へ","よ","う","こ","そ","\n",
                          "ゲ","ー","ム","モ","ー","ド","を","選","択","し","て","ね"};

        if(text1Tmr %  textInterval == 0 && text1Tmr >=  textInterval * 2 && text1Tmr /  textInterval < text1.Length + 2)
        {
            text_1.text += text1[text1Tmr /  textInterval - 2];
        }

        if(text1Tmr /  textInterval == text1.Length + 3)
        {
            text_1.text = "";
            tutorialButton.SetActive(true);
            playNowButton.SetActive(true);
        }

        text1Tmr++;
        if(text1Tmr == 20){text_1.text = "";}
    }

    void tutorialText1Create()
    {
        if(GameManager_Sc.idx != 1){return;}

        string[] tutorialText1 = {"チ","ュ","ー","ト","リ","ア","ル","を","開","始","し","ま","す"};

        if(tutorialText1Tmr /  textInterval == tutorialText1.Length + 2){GameManager_Sc.idx = 2;return;}

        if(tutorialText1Tmr %  textInterval == 0 && tutorialText1Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText1[tutorialText1Tmr /  textInterval - 2];
        }

        tutorialText1Tmr++;
        if(tutorialText1Tmr == 20){text_1.text = "";}
    }

    void tutorialText2Create()
    {
        if(GameManager_Sc.idx != 2){return;}

        string[] tutorialText2 = {"ま","ず","は","ク","リ","ッ","ク","し","て","\n",
                                  "玉","を","発","射","し","て","み","ま","し","ょ","う"};

        text_2.text = "玉を発射：" + shot10Times + " / 10";

        if(tutorialText2Tmr /  textInterval == tutorialText2.Length + 2){return;}

        if(tutorialText2Tmr %  textInterval == 0 && tutorialText2Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText2[tutorialText2Tmr /  textInterval - 2];
        }

        tutorialText2Tmr++;
        if(tutorialText2Tmr == 20){text_1.text = "";}
    }

    void tutorialText3Create()
    {
        if(GameManager_Sc.idx != 3){return;}

        string[] tutorialText3 = {"W","ま","た","は","S","キ","ー","で","ハ","ン","ド","ル","を","回","し","\n",
                                  "弾","速","を","調","節","で","き","ま","す"};

        text_2.text = "最高速度で玉を発射：" + maxShot + " / 1 \n" +
                      "最低速度で玉を発射：" + minShot + " / 1";

        if(tutorialText3Tmr /  textInterval == tutorialText3.Length + 2){return;}

        if(tutorialText3Tmr %  textInterval == 0 && tutorialText3Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText3[tutorialText3Tmr /  textInterval - 2];
        }

        tutorialText3Tmr++;
        if(tutorialText3Tmr == 20){text_1.text = "";}
    }

    void tutorialText4Create()
    {
        if(GameManager_Sc.idx != 4){return;}

        string[] tutorialText4 = {"玉","が","落","ち","た","場","所","に","応","じ","て","\n",
                                  "出","玉","を","獲","得","で","き","ま","す"};

        text_2.text = "３点の場所に玉を落とす：" + point3 + " / 1 \n" +
                      "２点の場所に玉を落とす：" + point2 + " / 1 \n" +
                      "１点の場所に玉を落とす：" + point1 + " / 1 \n" +
                      "０点の場所に玉を落とす：" + point0 + " / 1";

        if(tutorialText4Tmr /  textInterval == tutorialText4.Length + 2){return;}

        if(tutorialText4Tmr %  textInterval == 0 && tutorialText4Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText4[tutorialText4Tmr /  textInterval - 2];
        }

        tutorialText4Tmr++;
        if(tutorialText4Tmr == 20){text_1.text = "";}
    }

    void tutorialText5Create()
    {
        if(GameManager_Sc.idx != 5){return;}

        string[] tutorialText5 = {"玉","を","ジ","ャ","ッ","ク","ポ","ッ","ト","に","\n",
                                  "入","れ","る","と","ス","ロ","ッ","ト","が","回","り","ま","す"};

        text_2.text = "玉を３つのうちどれか１つの\nジャックポットに入れる\n：" + SlotManager_Sc.slotCount + " / 1";

        if(tutorialText5Tmr /  textInterval == tutorialText5.Length + 2){return;}

        if(tutorialText5Tmr %  textInterval == 0 && tutorialText5Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText5[tutorialText5Tmr /  textInterval - 2];
        }

        tutorialText5Tmr++;
        if(tutorialText5Tmr == 20){text_1.text = "";}
    }

    void tutorialText6Create()
    {
        if(GameManager_Sc.idx != 6){return;}

        string[] tutorialText6 = {"ボ","タ","ン","を","押","し","ス","ロ","ッ","ト","を","揃","え","る","と","\n",
                                  "出","玉","を","５","０","個","獲","得","で","き","ま","す"};

        text_2.text = "スペースキーを押して\n３つのスロットを\n同じ数字で止める\n：" + SlotManager_Sc.successCount + " / 1";

        if(tutorialText6Tmr /  textInterval == tutorialText6.Length + 2){return;}

        if(tutorialText6Tmr %  textInterval == 0 && tutorialText6Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText6[tutorialText6Tmr /  textInterval - 2];
        }

        tutorialText6Tmr++;
        if(tutorialText6Tmr == 20){text_1.text = "";}
    }

    void tutorialText7Create()
    {
        if(GameManager_Sc.idx != 7){return;}

        string[] tutorialText7 = {"こ","れ","で","チ","ュ","ー","ト","リ","ア","ル","を","終","わ","り","ま","す"};

        if(tutorialText7Tmr /  textInterval == tutorialText7.Length + 2){GameManager_Sc.idx = 8;return;}

        if(tutorialText7Tmr %  textInterval == 0 && tutorialText7Tmr >=  textInterval * 2)
        {
            text_1.text += tutorialText7[tutorialText7Tmr /  textInterval - 2];
        }

        tutorialText7Tmr++;
        if(tutorialText7Tmr == 20){text_1.text = ""; text_2.text = "";}
    }

    void playNowTextCreate()
    {
        if(GameManager_Sc.idx != 8){return;}

        string[] playNowText = {"ゲ","ー","ム","ス","タ","ー","ト"};

        if(playNowTextTmr /  textInterval == playNowText.Length + 2){
            Shooting_Sc.shotCount = 20;
            GameManager_Sc.idx = 9;
            return;
        }

        if(playNowTextTmr %  textInterval == 0 && playNowTextTmr >=  textInterval * 2)
        {
            text_1.text += playNowText[playNowTextTmr / textInterval - 2];
        }

        playNowTextTmr++;
        if(playNowTextTmr == 20){text_1.text = "";}
    }

    void textShotCount()
    {
        if(GameManager_Sc.idx != 9){return;}

        text_1.fontSize = 30;
        text_1.text = "         " + "残玉:" +  Shooting_Sc.shotCount;
    }
}