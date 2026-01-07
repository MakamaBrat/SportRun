using UnityEngine;
using UnityEngine.UI;

public class SettingsSwitcher : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource musicSource;
    public AudioSource[] sfxSources;

    [Header("UI Images")]
    public Image musicImage;
    public Image sfxImage;
    public Image dummyImage;

    [Header("Music Sprites")]
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    [Header("SFX Sprites")]
    public Sprite sfxOnSprite;
    public Sprite sfxOffSprite;

    [Header("Dummy Sprites")]
    public Sprite dummyOnSprite;
    public Sprite dummyOffSprite;

    [Header("States")]
    public bool musicOn = true;
    public bool sfxOn = true;
    public bool dummyOn = true;

    [Header("Transparency Settings")]
    [Range(0f, 1f)] public float onAlpha = 1f;
    [Range(0f, 1f)] public float offAlpha = 0.5f;

    private void Start()
    {
        ApplyMusicState();
        ApplySfxState();
        ApplyDummyState();
    }

    // --------------------
    // SWITCHERS
    // --------------------

    public void SwitchMusic()
    {
        musicOn = !musicOn;
        ApplyMusicState();
    }

    public void SwitchSfx()
    {
        sfxOn = !sfxOn;
        ApplySfxState();
    }

    public void SwitchDummy()
    {
        dummyOn = !dummyOn;
        ApplyDummyState();
    }

    // --------------------
    // APPLY STATES
    // --------------------

    void ApplyMusicState()
    {
        if (musicSource != null)
            musicSource.mute = !musicOn;

        ApplyImageState(
            musicImage,
            musicOn,
            musicOnSprite,
            musicOffSprite
        );
    }

    void ApplySfxState()
    {
        foreach (var sfx in sfxSources)
            if (sfx != null)
                sfx.mute = !sfxOn;

        ApplyImageState(
            sfxImage,
            sfxOn,
            sfxOnSprite,
            sfxOffSprite
        );
    }

    void ApplyDummyState()
    {
        ApplyImageState(
            dummyImage,
            dummyOn,
            dummyOnSprite,
            dummyOffSprite
        );
    }

    // --------------------
    // HELPER
    // --------------------

    void ApplyImageState(Image img, bool state, Sprite onSprite, Sprite offSprite)
    {
        if (img == null)
            return;

        // Прозрачность
        Color c = img.color;
        c.a = state ? onAlpha : offAlpha;
        img.color = c;

        // Спрайт
        if (onSprite != null && offSprite != null)
        {
            img.sprite = state ? onSprite : offSprite;
            img.SetNativeSize();
        }
    }
}
