using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private Slider HealthBar;

    public static HudController Instance;

    [SerializeField]
    private TMP_Text WaveText;

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeWaveCount(int wave, int waveMax)
    {
        WaveText.text = $"Wave:  {wave}/{waveMax}";
    }

    public void ChangeHpPoint(int hp)
    {
        HealthBar.value = hp;
    }
}
