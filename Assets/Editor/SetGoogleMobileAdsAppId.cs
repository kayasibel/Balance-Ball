using UnityEditor;
using UnityEngine;

// Automatically sets the Google Mobile Ads Android App ID in the plugin settings asset
[InitializeOnLoad]
internal static class SetGoogleMobileAdsAppId
{
    private const string SettingsAssetPath = "Assets/GoogleMobileAds/Resources/GoogleMobileAdsSettings.asset";
    private const string AndroidAppId = "ca-app-pub-9732851153400143~2793553335";

    static SetGoogleMobileAdsAppId()
    {
        EditorApplication.delayCall += ApplyIfNeeded;
    }

    private static void ApplyIfNeeded()
    {
        var asset = AssetDatabase.LoadAssetAtPath<Object>(SettingsAssetPath);
        if (asset == null)
        {
            Debug.LogWarning("GoogleMobileAds settings asset not found at " + SettingsAssetPath);
            return;
        }

        var so = new SerializedObject(asset);
        var prop = so.FindProperty("adMobAndroidAppId");
        if (prop == null)
        {
            Debug.LogWarning("Property 'adMobAndroidAppId' not found on GoogleMobileAdsSettings asset.");
            return;
        }

        if (string.IsNullOrEmpty(prop.stringValue))
        {
            prop.stringValue = AndroidAppId;
            so.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
            Debug.Log("Set GoogleMobileAds Android App ID to " + AndroidAppId);
        }
    }
}
