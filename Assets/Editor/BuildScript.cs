using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/Game.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "SportRun.aab";
        string apkPath = "SportRun.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64= "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";
        string keystorePass = "123qq123";
        string keyAlias = "sportball";
        string keyPass = "123qq123";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

    PlayerSettings.Android.useCustomKeystore = true;
    PlayerSettings.Android.keystoreName = tempKeystorePath;
    PlayerSettings.Android.keystorePass = keystorePass;
    PlayerSettings.Android.keyaliasName = keyAlias;
    PlayerSettings.Android.keyaliasPass = keyPass;

    Debug.Log("Android signing configured from Base64 keystore.");
}
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. Сборка APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}
