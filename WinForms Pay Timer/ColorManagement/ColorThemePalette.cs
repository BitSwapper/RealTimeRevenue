using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Pay_Timer.ColorManagement;
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
        DisabledButtonColor = Color.FromArgb(255, 155, 155, 155)
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
        MoneyFontColor = Color.WhiteSmoke
    };

    public static ColorTheme OceanBreeze { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 135, 196, 215),
        FontColor = Color.FromArgb(255, 3, 43, 68),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 52, 168, 90),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 55, 80, 80),
        TimerColor = Color.White,
        MoneyFontColor = Color.White
    };

    public static ColorTheme Sunset { get; } = new()
    {
        UseDarkMode = false,
        ColorBg = Color.FromArgb(255, 255, 192, 128),
        FontColor = Color.FromArgb(255, 102, 51, 0),
        FontColorListViewCaption = Color.WhiteSmoke,
        ButtonColor = Color.FromArgb(255, 255, 153, 0),
        ButtonFontColor = Color.White,
        DisabledButtonColor = Color.FromArgb(255, 128, 80, 60),
        TimerColor = Color.Black,
        MoneyFontColor = Color.Black
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
        TimerColor = Color.FromArgb(255, 230, 230, 250),
        MoneyFontColor = Color.FromArgb(255, 230, 230, 250)
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
        TimerColor = Color.White,
        MoneyFontColor = Color.White
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
        TimerColor = Color.Black,
        MoneyFontColor = Color.Black
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
        TimerColor = Color.White,
        MoneyFontColor = Color.White
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
        TimerColor = Color.White,
        MoneyFontColor = Color.White
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
        TimerColor = Color.White,
        MoneyFontColor = Color.White
    };
}
