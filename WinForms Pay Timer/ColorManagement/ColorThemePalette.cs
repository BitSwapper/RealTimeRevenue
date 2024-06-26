﻿namespace RealTime_Revenue.ColorManagement;
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

    public static ColorTheme Stealth { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 20, 20, 25),
        FontColor = Color.DarkGray,
        FontColorListViewCaption = Color.FromArgb(255, 50, 150, 255),
        ButtonColor = Color.FromArgb(255, 40, 40, 45),
        ButtonFontColor = Color.FromArgb(255, 200, 200, 205),
        DisabledButtonColor = Color.FromArgb(255, 60, 60, 65),
        TimerColor = Color.FromArgb(255, 108, 108, 158),
        MoneyFontColor = Color.FromArgb(255, 80, 180, 255)
    };

    public static ColorTheme GrayBlob { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 45, 45, 55),
        FontColor = Color.LightGray,
        FontColorListViewCaption = Color.FromArgb(255, 170, 170, 180),
        ButtonColor = Color.FromArgb(255, 90, 90, 100),
        ButtonFontColor = Color.WhiteSmoke,
        DisabledButtonColor = Color.FromArgb(255, 60, 60, 70),
        TimerColor = Color.FromArgb(255, 140, 140, 150),
        MoneyFontColor = Color.Silver
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

    public static ColorTheme Earth { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 80, 42, 42),
        FontColor = Color.WhiteSmoke,
        FontColorListViewCaption = Color.LightGray,
        ButtonColor = Color.FromArgb(255, 130, 70, 70),
        ButtonFontColor = Color.FromArgb(255, 245, 245, 245),
        DisabledButtonColor = Color.FromArgb(255, 90, 50, 50),
        TimerColor = Color.FromArgb(255, 255, 215, 0),
        MoneyFontColor = Color.FromArgb(255, 85, 107, 47)
    };

    public static ColorTheme Rose { get; } = new()
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

    public static ColorTheme Frost { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 210, 220, 240),
        FontColor = Color.FromArgb(255, 100, 130, 190),
        FontColorListViewCaption = Color.FromArgb(255, 100, 130, 220),
        ButtonColor = Color.FromArgb(255, 180, 210, 240),
        ButtonFontColor = Color.DarkSlateGray,
        DisabledButtonColor = Color.FromArgb(255, 120, 140, 150),
        TimerColor = Color.FromArgb(255, 135, 206, 250),
        MoneyFontColor = Color.FromArgb(255, 64, 160, 88)
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

    public static ColorTheme Neon { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 18, 18, 30),
        FontColor = Color.FromArgb(255, 191, 0, 255),
        FontColorListViewCaption = Color.LightGray,
        ButtonColor = Color.FromArgb(255, 255, 50, 150),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 128, 128, 128),
        TimerColor = Color.FromArgb(255, 100, 255, 218),
        MoneyFontColor = Color.FromArgb(255, 0, 255, 0)
    };

    public static ColorTheme Cyber { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 10, 10, 20),
        FontColor = Color.FromArgb(255, 0, 255, 255),
        FontColorListViewCaption = Color.LightGray,
        ButtonColor = Color.FromArgb(255, 0, 150, 200),
        ButtonFontColor = Color.Black,
        DisabledButtonColor = Color.FromArgb(255, 50, 50, 60),
        TimerColor = Color.FromArgb(255, 0, 180, 230),
        MoneyFontColor = Color.FromArgb(255, 20, 240, 20)
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

    public static ColorTheme Midnight2 { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 0, 35, 64), // A deep midnight blue
        FontColor = Color.FromArgb(255, 189, 195, 199),  // A light gray
        FontColorListViewCaption = Color.FromArgb(255, 219, 112, 147), // A pale pinkish-red
        ButtonColor = Color.FromArgb(255, 55, 57, 70),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 30, 30, 40),
        TimerColor = Color.FromArgb(255, 128, 0, 128), // Purple
        MoneyFontColor = Color.FromArgb(255, 197, 225, 165), // A light green-yellow
    };

    public static ColorTheme Cyberpunk { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 22, 28, 35), // Darker background for cyberpunk
        FontColor = Color.FromArgb(255, 0, 255, 0), // Bright green text
        FontColorListViewCaption = Color.LimeGreen,
        ButtonColor = Color.FromArgb(255, 80, 80, 80),  // Dark gray button
        ButtonFontColor = Color.Aquamarine, // Light blue button text
        DisabledButtonColor = Color.FromArgb(255, 50, 50, 50),
        TimerColor = Color.Yellow, // Bright yellow timer
        MoneyFontColor = Color.Fuchsia, // Pink money  
    };

    public static ColorTheme EerieGlow { get; } = new()
    {
        UseDarkMode = true,
        ColorBg = Color.FromArgb(255, 30, 30, 50), // Dark blue-gray background
        FontColor = Color.GhostWhite,
        FontColorListViewCaption = Color.FromArgb(255, 125, 255, 255), // Light blue-green
        ButtonColor = Color.FromArgb(255, 60, 60, 80),
        ButtonFontColor = Color.Silver,
        DisabledButtonColor = Color.FromArgb(255, 40, 40, 60),
        TimerColor = Color.FromArgb(255, 255, 140, 0), // Orange-yellow
        MoneyFontColor = Color.LawnGreen, // Bright green money
    };
}
