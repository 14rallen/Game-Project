using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class ExperiencePopUp : MonoBehaviour
{
    public Text expGainedText;
    public Image expBackground;
    public Image expFiller;
    public Slider slider;
    public CanvasGroup canvas;

    private Timer startTimer;
    private ElapsedEventHandler eventHandler;

    private Timer fadeTimer;
    private ElapsedEventHandler fadeEventHandler;
    private float fadeInTime;
    private float fadeOutTime;
    private float currentFade;
    private bool fadedIn;

    private Timer fadeDelayTimer;
    private ElapsedEventHandler fadeDelayEventHandler;
    private float fadeDelayTime;

    //private Timer remainderTimer;
    private float currentXPRemainder;
    private float targetXPRemainder;
    private float maxXPRemainder;
    private float playerLevel;

    private float currentXP;
    private float targetXP;
    private float maxXP;
    private float animationTime;// = 2000;
    private float tempAnimationTime;
    private float interval;// = 1;
    private float currentAndTargetDivision;
    private float difference;
    private float currentAndMaxDivision;

    private float expGained;
    private float expGainedOnLevelUp;
    private float currentExpGained;
    private float currentExpGainedOnLevelUp;

    //private bool levelUp;

    // Start is called before the first frame update
    void Start()
    {
        canvas.alpha = 0;
        fadedIn = false;
        fadeDelayTime = 1000;

        startTimer = new Timer();
        fadeTimer = new Timer();
        fadeDelayTimer = new Timer();
        animationTime = 2000;
        interval = 1;
        fadeInTime = 700;
        fadeOutTime = 1200;
        eventHandler = new ElapsedEventHandler(Count);
    }

    // Update is called once per frame
    void Update()
    {
        canvas.alpha = currentFade;
        slider.value = currentAndMaxDivision;

        expGainedText.text = "";
        if (currentExpGained > 0)
        {
            expGainedText.text = "+ " + Mathf.Round(currentExpGained).ToString();
        }
    }

    public void GainExp(float current, float target, float max, bool onLevelUp = false)
    {
        startTimer.Dispose();
        fadeDelayTimer.Dispose();

        currentXP = current;
        targetXP = target;
        maxXP = max;
        difference = targetXP - currentXP;

        expGained = target - current;

        if(!onLevelUp)
        {
            currentExpGained = 0; 
            fadeTimer.Dispose();
            fadedIn = false;

            currentFade = 0;
            fadeTimer = new Timer();
            fadeTimer.Interval = interval;
            fadeEventHandler = new ElapsedEventHandler(Fade);
            fadeTimer.Enabled = true;
            fadeTimer.Elapsed += fadeEventHandler;

            expGainedOnLevelUp = target - current;
        }

        startTimer = new Timer();
        startTimer.Interval = interval;

        if(onLevelUp)
        {
            //Debug.Log("current: " + currentExpGainedOnLevelUp.ToString() + " gained total: " + expGainedOnLevelUp.ToString());
            float t = currentExpGainedOnLevelUp / expGainedOnLevelUp;
            tempAnimationTime = t * animationTime;
            //Debug.Log("division: " + t.ToString() + " temp time: " + tempAnimationTime.ToString());
        }
        else
        {
            tempAnimationTime = animationTime;
        }

        startTimer.Enabled = true;
        startTimer.Elapsed += eventHandler;
    }

    public void LevelUp(float current, float target, float max, float level)
    {
        playerLevel = level;
        currentXPRemainder = current;
        targetXPRemainder = target;
        maxXPRemainder = max;

        currentExpGainedOnLevelUp = target - current;

        //levelUp = true;
    }

    private void ExpGainOver()
    {
        startTimer.Dispose();

        fadeDelayTimer = new Timer();
        fadeDelayTimer.Interval = fadeDelayTime;
        fadeDelayEventHandler = new ElapsedEventHandler(FadeDelay);
        fadeDelayTimer.Enabled = true;
        fadeDelayTimer.Elapsed += fadeDelayEventHandler;
    }

    private void Count(object sender, ElapsedEventArgs e)
    {
        if(fadedIn)
        {
            currentXP = currentXP + (difference / (tempAnimationTime / interval));
            //currentAndTargetDivision = currentXP / targetXP;

            currentAndMaxDivision = currentXP / maxXP;

            currentExpGained = currentExpGained + (expGained / (tempAnimationTime / interval));

            if (currentXP >= maxXP && playerLevel < GlobalValues.max_level)
            {
                Debug.Log("Remainder current: " + currentXPRemainder.ToString() + ", target: " + targetXPRemainder.ToString() + ", max: " + maxXPRemainder.ToString());
                GainExp(currentXPRemainder, targetXPRemainder, maxXPRemainder, true);
            }

            if (currentXP >= targetXP)
            {
                ExpGainOver();
            }
        }
    }

    private void Fade(object sender, ElapsedEventArgs e)
    {
        if(!fadedIn)
        {
            if (currentFade >= 1)
            {
                fadedIn = true;
                fadeTimer.Dispose();
                fadeDelayTimer.Dispose();
            }
            else
            {
                currentFade = currentFade + (interval / fadeInTime);
            }
        }
        else
        {
            if (currentFade > 0)
            {
                currentFade = currentFade - (interval / fadeOutTime);
            }
            else
            {
                fadedIn = false;
                fadeTimer.Dispose();
                fadeDelayTimer.Dispose();
            }
        }
    }

    private void FadeDelay(object sender, ElapsedEventArgs e)
    {
        fadeTimer = new Timer();
        fadeTimer.Interval = interval;
        fadeEventHandler = new ElapsedEventHandler(Fade);
        fadeTimer.Enabled = true;
        fadeTimer.Elapsed += fadeEventHandler;

        fadeDelayTimer.Dispose();
    }
}
