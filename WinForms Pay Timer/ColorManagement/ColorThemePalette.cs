namespace RealTime_Revenue.ColorManagement;
public static class ColorThemePalette
{
    public static ColorTheme Light { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = SystemColors.Control,
        FontColor = Color.Black,
        FontColorListViewCaption = Color.Black,
        ButtonColor = Color.FromArgb(255, 225, 225, 225),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 155, 155, 155),
        TimerColor = Color.Black,
        MoneyFontColor = Color.Green,
    };

    public static ColorTheme Dark { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 24, 28, 35),
        FontColor = Color.WhiteSmoke,
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 59, 64, 76),
        ButtonFontColor = Color.WhiteSmoke,
        DisabledButtonColor = Color.FromArgb(255, 100, 100, 100),
        TimerColor = Color.WhiteSmoke,
        MoneyFontColor = Color.Green
    };


    public static ColorTheme Ocean { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 130, 190, 220),
        FontColor = Color.FromArgb(255, 0, 51, 80),
        FontColorListViewCaption = Color.LightGray,
        ButtonColor = Color.FromArgb(255, 45, 150, 100),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 50, 70, 70),
        TimerColor = Color.FromArgb(255, 0, 0, 128),
        MoneyFontColor = Color.FromArgb(255, 255, 215, 0)
    };

    public static ColorTheme Sunset { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 255, 204, 153),
        FontColor = Color.FromArgb(255, 158, 91, 91),
        FontColorListViewCaption = Color.LightGray,
        ButtonColor = Color.FromArgb(255, 255, 178, 102),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 153, 102, 80),
        TimerColor = Color.FromArgb(255, 139, 0, 0),
        MoneyFontColor = Color.FromArgb(255, 0, 191, 255)
    };

    public static ColorTheme Midnight { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 25, 25, 112),
        FontColor = Color.FromArgb(255, 192, 192, 192),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 75, 0, 130),
        ButtonFontColor = Color.FromArgb(255, 230, 230, 250),
        DisabledButtonColor = Color.FromArgb(255, 45, 45, 90),
        TimerColor = Color.DeepSkyBlue,
        MoneyFontColor = Color.Silver
    };

    public static ColorTheme RoseGarden { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 240, 128, 128),
        FontColor = Color.FromArgb(255, 0, 32, 0),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 205, 92, 92),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 165, 82, 82),
        TimerColor = Color.MistyRose,
        MoneyFontColor = Color.MediumVioletRed
    };

    public static ColorTheme Winter { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 225, 225, 255),
        FontColor = Color.FromArgb(255, 0, 0, 128),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 173, 216, 230),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 150, 190, 225),
        TimerColor = Color.LightSteelBlue,
        MoneyFontColor = Color.DeepSkyBlue
    };


    public static ColorTheme HighContrast { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 15, 15, 15),
        FontColor = Color.FromArgb(255, 255, 0, 255),
        FontColorListViewCaption = Color.FromArgb(255, 32, 32, 32),
        ButtonColor = Color.FromArgb(255, 0, 223, 23),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 60, 60, 60),
        TimerColor = Color.Yellow,
        MoneyFontColor = Color.Magenta
    };

    public static ColorTheme Halloween { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 34, 34, 34),
        FontColor = Color.FromArgb(255, 245, 130, 30),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 180, 30, 30),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 128, 128, 128),
        TimerColor = Color.Gold,
        MoneyFontColor = Color.OrangeRed
    };

    public static ColorTheme MutedHalloween { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 64, 64, 64),
        FontColor = Color.FromArgb(255, 210, 180, 140),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 140, 70, 70),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 128, 128, 128),
        TimerColor = Color.DarkKhaki,
        MoneyFontColor = Color.DarkOrange
    };
}
