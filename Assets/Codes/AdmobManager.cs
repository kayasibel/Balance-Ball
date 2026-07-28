using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobManager : MonoBehaviour
{
    public static AdmobManager Instance;
    private RewardedAd rewardedAd;
    private string rewardedAdUnitId = "ca-app-pub-9732851153400143/7739007026";
    private bool adLoaded = false;
    private Action onRewardedCallback;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { LoadRewardedAd(); });
    }

    // Uses the newer SDK pattern: RewardedAd.Load(adUnitId, request, callback)
    public void LoadRewardedAd()
    {
        try
        {
            AdRequest request = new AdRequest();
            RewardedAd.Load(rewardedAdUnitId, request, (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    adLoaded = false;
                    Debug.LogWarning("Failed to load rewarded ad: " + error.GetMessage());
                    return;
                }

                rewardedAd = ad;
                adLoaded = true;
                Debug.Log("Rewarded ad loaded (v11 API).");
            });
        }
        catch (Exception e)
        {
            Debug.LogWarning("LoadRewardedAd failed (maybe different SDK API): " + e);
        }
    }

    // Show with user-earned callback
    public void ShowRewardedAd(Action onRewarded = null)
    {
        this.onRewardedCallback = onRewarded;

        if (rewardedAd != null)
        {
            try
            {
                rewardedAd.Show((Reward reward) =>
                {
                    Debug.Log("User earned reward: " + reward.Amount);
                    InvokeRewardCallback();
                    // Reload after show
                    LoadRewardedAd();
                });
                return;
            }
            catch (Exception e)
            {
                Debug.LogWarning("ShowRewardedAd failed (maybe different SDK API): " + e);
            }
        }
        else
        {
            Debug.Log("Rewarded ad is not ready.");
        }

        // Reklam gosterilemedi. Oyuncuyu bekletme, ilerlemesine izin ver;
        // aksi halde level gecisi callback'e bagli oldugu icin oyun kilitleniyor.
        LoadRewardedAd();
        InvokeRewardCallback();
    }

    // Callback'i en fazla bir kez calistirir.
    private void InvokeRewardCallback()
    {
        Action cb = onRewardedCallback;
        onRewardedCallback = null;

        if (cb != null)
        {
            cb();
        }
    }
}
