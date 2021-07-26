using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Islemler : MonoBehaviour
{
    public AudioMixer audioMixer2;
    public GameObject seviyeler, islemler, ayarlar;
    public Text text1, text2, text3, text4, text5,text_zaman;
    public Button _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12;
    public Button kontrolEt;
    public Button[] butonlar = new Button[3];
    int randomSayi1, randomSayi2;
    public Slider sesSlider;
    public Dropdown islemDrop;
    int toplama, cikarma, carpma, bolme;
    int buton1_degeri, buton2_degeri, buton3_degeri;
    int level;
    public float zaman=20;
    string secilenislem;
    public bool zaman_baslat; 


    public void Start()
    {
        sesSlider.value = PlayerPrefs.GetFloat("ses2");
        islemDrop.value = PlayerPrefs.GetInt("islem");
        level = PlayerPrefs.GetInt("level");
        secilenislem = islemDrop.value.ToString();
        islemler.SetActive(false);
        seviyeler.SetActive(true);
        zaman_baslat = false;
        text_zaman.text = "" + (int)zaman;
        
        CevapKontrol();
        text3.enabled = false;
        _2.interactable = false;
        _3.interactable = false;
        _4.interactable = false;
        _5.interactable = false;
        _6.interactable = false;
        _7.interactable = false;
        _8.interactable = false;
        _9.interactable = false;
        _10.interactable = false;
        _11.interactable = false;
        _12.interactable = false;
    }
    public void Update()
    {       
        if (zaman_baslat == true)
        {
            zaman -= Time.deltaTime;
            text_zaman.text = "" + (int)zaman;            
            if (text_zaman.text == "0")
            {
                text4.text = "Zaman Doldu!!!";
                StartCoroutine(Wait());
                if (level == 1) { Btn1();}
                else if (level == 2) { Btn2();}
                else if (level == 3) { Btn3(); }
                else if (level == 4) { Btn4(); }
                else if (level == 5) { Btn5(); }
                else if (level == 6) { Btn6(); }
                else if (level == 7) { Btn7(); }
                else if (level == 8) { Btn8(); }
                else if (level == 9) { Btn9(); }
                else if (level == 10) { Btn10(); }
                else if (level == 11) { Btn11(); }
                else if (level == 12) { Btn12(); }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        
        text4.text = "";
    }
    //Secilen işlemi hafızaya al
    public void Islem(int islemDegeri)
    {
        PlayerPrefs.SetInt("islem", islemDegeri);
    }
//secilen ses seviyesini hafızaya al
    public void Ses(float sesDegeri)
    {
        audioMixer2.SetFloat("ses2", Mathf.Log10(sesDegeri) * 20);
        PlayerPrefs.SetFloat("ses2", sesDegeri);
    }
    public void Back()
    {
        secilenislem = islemDrop.value.ToString();
        islemDrop.value = PlayerPrefs.GetInt("islem");
        seviyeler.SetActive(true);
        ayarlar.SetActive(false);
    }
    public void Settings()
    {
        seviyeler.SetActive(false);
        ayarlar.SetActive(true);
    }
    public void Cikis()
    {
        SceneManager.LoadScene("AnaMenü");
        
    }
    public int RandomNumber(int min, int max)
    {
        int a = Random.Range(min, max);
        return a;
    }
    public int RandomButton1(int min, int max)
    {
        int a = Random.Range(min, max);
        return a;
    }
    public void Temizle()
    {
        text4.text = "";
        GameObject.Find("A").GetComponentInChildren<Image>().color = Color.yellow;
        GameObject.Find("B").GetComponentInChildren<Image>().color = Color.yellow;
        GameObject.Find("C").GetComponentInChildren<Image>().color = Color.yellow;

        GameObject.Find("A").GetComponentInChildren<Button>().interactable = true;
        GameObject.Find("B").GetComponentInChildren<Button>().interactable = true;
        GameObject.Find("C").GetComponentInChildren<Button>().interactable = true;
    }
    public void LevelButton(int butonAdi)
    {
        switch (butonAdi)
        {
            case 1:            
                Btn1();                
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();                
                
                break;
            case 2:
                Btn2();
                PlayerPrefs.SetInt("level", butonAdi);                
                Temizle();
                break;
            case 3:
                Btn3();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 4:
                Btn4();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 5:
                Btn5();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 6:
                Btn6();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 7:
                Btn7();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 8:
                Btn8();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();                
                break;
            case 9:
                Btn9();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 10:
                Btn10();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 11:
                Btn11();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            case 12:
                Btn12();
                PlayerPrefs.SetInt("level", butonAdi);
                Temizle();
                break;
            default:
                break;
        }
    }
    public void Btn1()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
                //Toplama
                if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(0, 5);
                randomSayi2 = RandomNumber(0, 5);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(0, 9);
                buton2_degeri = RandomButton1(0, 9);
                buton3_degeri = RandomButton1(0, 9);
            } 
            //Çıkarma
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 11);
                    randomSayi2 = RandomNumber(1, 11);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 11);
                        buton2_degeri = RandomButton1(0, 11);
                        buton3_degeri = RandomButton1(0, 11);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 11);
                        randomSayi2 = RandomNumber(1, 11);
                    }
                }
            }
            //Çarpma
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(1, 6);
                randomSayi2 = RandomNumber(1, 6);            
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 25);
                buton2_degeri = RandomButton1(1, 25);
                buton3_degeri = RandomButton1(1, 25);            
            }
            //Bölme
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 11);
                    randomSayi2 = RandomNumber(1, 11);
                    //Bölünen sayılar tam bölünmeli
                    if (randomSayi1 % randomSayi2 == 0)
                    {                    
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();            
                        buton1_degeri = RandomButton1(1, 11);
                        buton2_degeri = RandomButton1(1, 11);
                        buton3_degeri = RandomButton1(1, 11);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 11);
                        randomSayi2 = RandomNumber(1, 11);
                    }
                }
            }
            //Şıklar birbirinden farklı olmalı       
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
                {
                    GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                    GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                    GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                    break;
                }                    
        }
        IslemSec();
    }
    public void Btn2()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(10, 16);
                randomSayi2 = RandomNumber(10, 16);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(20, 31);
                buton2_degeri = RandomButton1(20, 31);
                buton3_degeri = RandomButton1(20, 31);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(10, 21);
                    randomSayi2 = RandomNumber(10, 21);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 11);
                        buton2_degeri = RandomButton1(0, 11);
                        buton3_degeri = RandomButton1(0, 11);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(10, 21);
                        randomSayi2 = RandomNumber(10, 21);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(1, 8);
                randomSayi2 = RandomNumber(1, 8);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 50);
                buton2_degeri = RandomButton1(1, 50);
                buton3_degeri = RandomButton1(1, 50);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 21);
                    randomSayi2 = RandomNumber(1, 21);
                    if (randomSayi1 % randomSayi2 == 0)
                    {

                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 21);
                        buton2_degeri = RandomButton1(1, 21);
                        buton3_degeri = RandomButton1(1, 21);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 21);
                        randomSayi2 = RandomNumber(1, 21);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn3()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(20, 31);
                randomSayi2 = RandomNumber(20, 31);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(40, 61);
                buton2_degeri = RandomButton1(40, 61);
                buton3_degeri = RandomButton1(40, 61);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(20, 31);
                    randomSayi2 = RandomNumber(20, 31);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 11);
                        buton2_degeri = RandomButton1(0, 11);
                        buton3_degeri = RandomButton1(0, 11);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(20, 31);
                        randomSayi2 = RandomNumber(20, 31);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(1, 10);
                randomSayi2 = RandomNumber(1, 10);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 82);
                buton2_degeri = RandomButton1(1, 82);
                buton3_degeri = RandomButton1(1, 82);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 31);
                    randomSayi2 = RandomNumber(1, 31);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 31);
                        buton2_degeri = RandomButton1(1, 31);
                        buton3_degeri = RandomButton1(1, 31);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 31);
                        randomSayi2 = RandomNumber(1, 31);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn4()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(30, 51);
                randomSayi2 = RandomNumber(30, 51);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(60, 101);
                buton2_degeri = RandomButton1(60, 101);
                buton3_degeri = RandomButton1(60, 101);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(30, 51);
                    randomSayi2 = RandomNumber(30, 51);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 21);
                        buton2_degeri = RandomButton1(0, 21);
                        buton3_degeri = RandomButton1(0, 21);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(30, 51);
                        randomSayi2 = RandomNumber(30, 51);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(3, 10);
                randomSayi2 = RandomNumber(3, 10);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(9, 82);
                buton2_degeri = RandomButton1(9, 82);
                buton3_degeri = RandomButton1(9, 82);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 41);
                    randomSayi2 = RandomNumber(1, 41);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 41);
                        buton2_degeri = RandomButton1(1, 41);
                        buton3_degeri = RandomButton1(1, 41);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 41);
                        randomSayi2 = RandomNumber(1, 41);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn5()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(40, 71);
                randomSayi2 = RandomNumber(40, 71);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(80, 141);
                buton2_degeri = RandomButton1(80, 141);
                buton3_degeri = RandomButton1(80, 141);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(40, 61);
                    randomSayi2 = RandomNumber(40, 61);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 21);
                        buton2_degeri = RandomButton1(0, 21);
                        buton3_degeri = RandomButton1(0, 21);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(40, 61);
                        randomSayi2 = RandomNumber(40, 61);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(4, 13);
                randomSayi2 = RandomNumber(4, 13);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(16, 170);
                buton2_degeri = RandomButton1(16, 170);
                buton3_degeri = RandomButton1(16, 170);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 51);
                    randomSayi2 = RandomNumber(1, 51);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 51);
                        buton2_degeri = RandomButton1(1, 51);
                        buton3_degeri = RandomButton1(1, 51);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 51);
                        randomSayi2 = RandomNumber(1, 51);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn6()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(50, 81);
                randomSayi2 = RandomNumber(50, 81);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(100, 161);
                buton2_degeri = RandomButton1(100, 161);
                buton3_degeri = RandomButton1(100, 161);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(50, 71);
                    randomSayi2 = RandomNumber(50, 71);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 21);
                        buton2_degeri = RandomButton1(0, 21);
                        buton3_degeri = RandomButton1(0, 21);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(50, 71);
                        randomSayi2 = RandomNumber(50, 71);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(5, 10);
                randomSayi2 = RandomNumber(5, 10);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(25, 82);
                buton2_degeri = RandomButton1(25, 82);
                buton3_degeri = RandomButton1(25, 82);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 71);
                    randomSayi2 = RandomNumber(1, 71);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 71);
                        buton2_degeri = RandomButton1(1, 71);
                        buton3_degeri = RandomButton1(1, 71);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 71);
                        randomSayi2 = RandomNumber(1, 71);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn7()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true) { 
        if (secilenislem == "0")
        {
            randomSayi1 = RandomNumber(70, 101);
            randomSayi2 = RandomNumber(70, 101);
            text1.text = randomSayi1.ToString();
            text2.text = randomSayi2.ToString();
            buton1_degeri = RandomButton1(140, 201);
            buton2_degeri = RandomButton1(140, 201);
            buton3_degeri = RandomButton1(140, 201);
        }
        if (secilenislem == "1")
        {
            while (true)
            {
                randomSayi1 = RandomNumber(70, 101);
                randomSayi2 = RandomNumber(70, 101);
                if (randomSayi1 > randomSayi2)
                {
                    text1.text = randomSayi1.ToString();
                    text2.text = randomSayi2.ToString();
                    buton1_degeri = RandomButton1(0, 31);
                    buton2_degeri = RandomButton1(0, 31);
                    buton3_degeri = RandomButton1(0, 31);
                    break;
                }
                else
                {
                    randomSayi1 = RandomNumber(70, 101);
                    randomSayi2 = RandomNumber(70, 101);
                }
            }
        }
        if (secilenislem == "2")
        {
            randomSayi1 = RandomNumber(2, 15);
            randomSayi2 = RandomNumber(2, 15);
            text1.text = randomSayi1.ToString();
            text2.text = randomSayi2.ToString();
            buton1_degeri = RandomButton1(4, 200);
            buton2_degeri = RandomButton1(4, 200);
            buton3_degeri = RandomButton1(4, 200);
        }
        if (secilenislem == "3")
        {
            while (true)
            {
                randomSayi1 = RandomNumber(1, 81);
                randomSayi2 = RandomNumber(1, 81);
                if (randomSayi1 % randomSayi2 == 0)
                {
                    text1.text = randomSayi1.ToString();
                    text2.text = randomSayi2.ToString();
                    buton1_degeri = RandomButton1(1, 81);
                    buton2_degeri = RandomButton1(1, 81);
                    buton3_degeri = RandomButton1(1, 81);
                    break;
                }
                else
                {
                    randomSayi1 = RandomNumber(1, 81);
                    randomSayi2 = RandomNumber(1, 81);
                }
            }
        }
        if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
        {
            GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
            GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
            GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
            break;
        }
    }
        IslemSec();
    }
    public void Btn8()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(80, 111);
                randomSayi2 = RandomNumber(80, 111);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(160, 221);
                buton2_degeri = RandomButton1(160, 221);
                buton3_degeri = RandomButton1(160, 221);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(80, 111);
                    randomSayi2 = RandomNumber(80, 111);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 31);
                        buton2_degeri = RandomButton1(0, 31);
                        buton3_degeri = RandomButton1(0, 31);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(80, 111);
                        randomSayi2 = RandomNumber(80, 111);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(2, 16);
                randomSayi2 = RandomNumber(1, 4);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 226);
                buton2_degeri = RandomButton1(1, 226);
                buton3_degeri = RandomButton1(1, 226);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 101);
                    randomSayi2 = RandomNumber(1, 101);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 101);
                        buton2_degeri = RandomButton1(1, 101);
                        buton3_degeri = RandomButton1(1, 101);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 101);
                        randomSayi2 = RandomNumber(1, 101);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn9()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(90, 121);
                randomSayi2 = RandomNumber(90, 121);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(180, 241);
                buton2_degeri = RandomButton1(180, 241);
                buton3_degeri = RandomButton1(180, 241);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(90, 121);
                    randomSayi2 = RandomNumber(90, 121);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 31);
                        buton2_degeri = RandomButton1(0, 31);
                        buton3_degeri = RandomButton1(0, 31);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(90, 121);
                        randomSayi2 = RandomNumber(90, 121);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(1, 5);
                randomSayi2 = RandomNumber(2, 10);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 36);
                buton2_degeri = RandomButton1(1, 36);
                buton3_degeri = RandomButton1(1, 36);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 121);
                    randomSayi2 = RandomNumber(1, 121);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 121);
                        buton2_degeri = RandomButton1(1, 121);
                        buton3_degeri = RandomButton1(1, 121);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 121);
                        randomSayi2 = RandomNumber(1, 121);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn10()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(100, 141);
                randomSayi2 = RandomNumber(100, 141);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(200, 281);
                buton2_degeri = RandomButton1(200, 281);
                buton3_degeri = RandomButton1(200, 281);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(100, 141);
                    randomSayi2 = RandomNumber(100, 141);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 41);
                        buton2_degeri = RandomButton1(0, 41);
                        buton3_degeri = RandomButton1(0, 41);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(100, 141);
                        randomSayi2 = RandomNumber(100, 141);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(1, 5);
                randomSayi2 = RandomNumber(1, 15);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(1, 57);
                buton2_degeri = RandomButton1(1, 57);
                buton3_degeri = RandomButton1(1, 57);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 151);
                    randomSayi2 = RandomNumber(1, 151);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 151);
                        buton2_degeri = RandomButton1(1, 151);
                        buton3_degeri = RandomButton1(1, 151);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 151);
                        randomSayi2 = RandomNumber(1, 151);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn11()
    {
        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(90, 121);
                randomSayi2 = RandomNumber(90, 121);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(180, 241);
                buton2_degeri = RandomButton1(180, 241);
                buton3_degeri = RandomButton1(180, 241);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(90, 121);
                    randomSayi2 = RandomNumber(90, 121);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 31);
                        buton2_degeri = RandomButton1(0, 31);
                        buton3_degeri = RandomButton1(0, 31);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(90, 121);
                        randomSayi2 = RandomNumber(90, 121);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(2, 10);
                randomSayi2 = RandomNumber(5, 15);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(2, 130);
                buton2_degeri = RandomButton1(2, 130);
                buton3_degeri = RandomButton1(2, 130);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 301);
                    randomSayi2 = RandomNumber(1, 301);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 301);
                        buton2_degeri = RandomButton1(1, 301);
                        buton3_degeri = RandomButton1(1, 301);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 301);
                        randomSayi2 = RandomNumber(1, 301);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void Btn12()
    {

        islemler.SetActive(true);
        seviyeler.SetActive(false);
        kontrolEt.interactable = false;
        zaman_baslat = true;
        zaman = 20;
        while (true)
        {
            if (secilenislem == "0")
            {
                randomSayi1 = RandomNumber(90, 121);
                randomSayi2 = RandomNumber(90, 121);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(180, 241);
                buton2_degeri = RandomButton1(180, 241);
                buton3_degeri = RandomButton1(180, 241);
            }
            if (secilenislem == "1")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(90, 121);
                    randomSayi2 = RandomNumber(90, 121);
                    if (randomSayi1 > randomSayi2)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(0, 31);
                        buton2_degeri = RandomButton1(0, 31);
                        buton3_degeri = RandomButton1(0, 31);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(90, 121);
                        randomSayi2 = RandomNumber(90, 121);
                    }
                }
            }
            if (secilenislem == "2")
            {
                randomSayi1 = RandomNumber(5, 10);
                randomSayi2 = RandomNumber(10, 20);
                text1.text = randomSayi1.ToString();
                text2.text = randomSayi2.ToString();
                buton1_degeri = RandomButton1(25, 175);
                buton2_degeri = RandomButton1(25, 175);
                buton3_degeri = RandomButton1(25, 175);
            }
            if (secilenislem == "3")
            {
                while (true)
                {
                    randomSayi1 = RandomNumber(1, 501);
                    randomSayi2 = RandomNumber(1, 501);
                    if (randomSayi1 % randomSayi2 == 0)
                    {
                        text1.text = randomSayi1.ToString();
                        text2.text = randomSayi2.ToString();
                        buton1_degeri = RandomButton1(1, 501);
                        buton2_degeri = RandomButton1(1, 501);
                        buton3_degeri = RandomButton1(1, 501);
                        break;
                    }
                    else
                    {
                        randomSayi1 = RandomNumber(1, 501);
                        randomSayi2 = RandomNumber(1, 501);
                    }
                }
            }
            if (buton1_degeri != buton2_degeri && buton2_degeri != buton3_degeri && buton1_degeri != buton3_degeri)
            {
                GameObject.Find("A").GetComponentInChildren<Text>().text = buton1_degeri.ToString();
                GameObject.Find("B").GetComponentInChildren<Text>().text = buton2_degeri.ToString();
                GameObject.Find("C").GetComponentInChildren<Text>().text = buton3_degeri.ToString();
                break;
            }
        }
            IslemSec();
    }
    public void IslemSec()
    {
        switch (secilenislem)
        {
            case "0":
                toplama = randomSayi1 + randomSayi2;
                text3.text = toplama.ToString();
                text5.text = "+";
                break;
            case "1":
                cikarma = randomSayi1 - randomSayi2;
                text3.text = cikarma.ToString();
                text5.text = "-";
                break;
            case "2":
                carpma = randomSayi1 * randomSayi2;
                text3.text = carpma.ToString();
                text5.text = "x";
                break;
            case "3":
                bolme = randomSayi1 / randomSayi2;
                text3.text = bolme.ToString();
                text5.text = "/";
                break;
            default:
                break;
        }
        GameObject.Find(butonlar[Random.Range(0, butonlar.Length)].GetComponentInChildren<Text>().text = text3.text);
    }
    public void Buton1()
    {
        if (GameObject.Find("A").GetComponentInChildren<Text>().text == text3.text)
        {
            text4.text = "Bildiniz :))";
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.green;
            GameObject.Find("A").GetComponentInChildren<Image>().color = Color.green;
            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("B").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("C").GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            text4.text = "Bilemediniz :((";
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.red;
            GameObject.Find("A").GetComponentInChildren<Image>().color = Color.red;
            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("B").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("C").GetComponentInChildren<Button>().interactable = false;
        }
    }
    public void Buton2()
    {
        if (GameObject.Find("B").GetComponentInChildren<Text>().text == text3.text)
        {
            text4.text = "Bildiniz :))";
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.green;
            GameObject.Find("B").GetComponentInChildren<Image>().color = Color.green;
            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("A").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("C").GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            text4.text = "Bilemediniz :((";
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.red;
            GameObject.Find("B").GetComponentInChildren<Image>().color = Color.red;
            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("A").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("C").GetComponentInChildren<Button>().interactable = false;
        }
    }
    public void Buton3()
    {
        if (GameObject.Find("C").GetComponentInChildren<Text>().text == text3.text)
        {
            text4.text = "Bildiniz :))";
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.green;
            GameObject.Find("C").GetComponentInChildren<Image>().color = Color.green;
            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("B").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("A").GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            text4.text = "Bilemediniz :((";
            
            GameObject.Find("text4").GetComponentInChildren<Text>().color = Color.red;
            GameObject.Find("C").GetComponentInChildren<Image>().color = Color.red;

            GameObject.Find("Kontrol").GetComponentInChildren<Button>().interactable = true;
            GameObject.Find("B").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("A").GetComponentInChildren<Button>().interactable = false;
        }        
    }    
    public void CevapKontrol()
    {
        islemler.SetActive(false);
        seviyeler.SetActive(true);
        level = PlayerPrefs.GetInt("level");
        if (text4.text == "Bilemediniz :((")
        {
            seviyeler.SetActive(true);            
        }
        else if (text4.text== "Bildiniz :))")
        {
            DogruYanlis();
        }
     }
    public void DogruYanlis()
    {
        if (level == 1)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = false;
            _4.interactable = false;
            _5.interactable = false;
            _6.interactable = false;
            _7.interactable = false;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 2)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = false;
            _5.interactable = false;
            _6.interactable = false;
            _7.interactable = false;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 3)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = false;
            _6.interactable = false;
            _7.interactable = false;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 4)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = false;
            _7.interactable = false;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 5)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = false;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 6)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = false;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 7)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = true;
            _9.interactable = false;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 8)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = true;
            _9.interactable = true;
            _10.interactable = false;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 9)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = true;
            _9.interactable = true;
            _10.interactable = true;
            _11.interactable = false;
            _12.interactable = false;
        }
        if (level == 10)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = true;
            _9.interactable = true;
            _10.interactable = true;
            _11.interactable = true;
            _12.interactable = false;
        }
        if (level == 11)
        {
            _1.interactable = true;
            _2.interactable = true;
            _3.interactable = true;
            _4.interactable = true;
            _5.interactable = true;
            _6.interactable = true;
            _7.interactable = true;
            _8.interactable = true;
            _9.interactable = true;
            _10.interactable = true;
            _11.interactable = true;
            _12.interactable = true;
        }
    }
}