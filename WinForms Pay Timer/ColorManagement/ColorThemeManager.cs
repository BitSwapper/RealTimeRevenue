using RealTime_Revenue.Properties;

namespace RealTime_Revenue.ColorManagement;

public static partial class ColorThemeManager
{
    public static ColorTheme? CurTheme { get; private set; }

    public static void UpdateColorScheme(Form form)
    {
        CurTheme = GetTheme((ThemeChoice)Settings.Default.ColorThemeOption);
        form.BackColor = CurTheme.ColorBg;
        form.ForeColor = CurTheme.FontColor;
        ChangeColorThemeOfAllControls(form, CurTheme);
    }
    static ColorTheme GetTheme(ThemeChoice mode) => mode switch
    {
        ThemeChoice.Light => ColorThemePalette.Light,
        ThemeChoice.Dark => ColorThemePalette.Dark,
        ThemeChoice.Stealth => ColorThemePalette.Stealth,
        ThemeChoice.GrayBlob => ColorThemePalette.GrayBlob,
        ThemeChoice.Ocean => ColorThemePalette.Ocean,
        ThemeChoice.Sunset => ColorThemePalette.Sunset,
        ThemeChoice.Earth => ColorThemePalette.Earth,
        ThemeChoice.Rose => ColorThemePalette.Rose,
        ThemeChoice.Winter => ColorThemePalette.Winter,
        ThemeChoice.Frost => ColorThemePalette.Frost,
        ThemeChoice.Halloween => ColorThemePalette.Halloween,
        ThemeChoice.MutedHalloween => ColorThemePalette.MutedHalloween,
        ThemeChoice.Neon => ColorThemePalette.Neon,
        ThemeChoice.Cyber => ColorThemePalette.Cyber,
        ThemeChoice.HighContrast => ColorThemePalette.HighContrast,
        _ => ColorThemePalette.Dark,
    };



    static void ChangeColorThemeOfAllControls(Control control, ColorTheme theme)
    {
        foreach(Control childControl in control.Controls)
        {
            if(childControl is Button button) ApplyButtonColors(theme, button);
            else if(childControl is Form form) ApplyFormColors(theme, form);
            else if(childControl is Label label) ApplyLabelColors(theme, label);
            else if(childControl is ListView LV) ApplyListViewColors(theme, LV);

            if(childControl.Controls.Count > 0) ChangeColorThemeOfAllControls(childControl, theme);
        }


        static void ApplyButtonColors(ColorTheme theme, Button button)
        {
            button.BackColor = theme.ButtonColor;
            button.ForeColor = theme.ButtonFontColor;
            if(!button.Enabled)
                button.BackColor = theme.DisabledButtonColor;

            button.EnabledChanged += (sender, e) =>
            {
                Button btn = (Button)sender!;
                if(btn.Enabled)
                {
                    btn.BackColor = theme.ButtonColor;
                    btn.ForeColor = theme.ButtonFontColor;
                }
                else
                    btn.BackColor = theme.DisabledButtonColor;
            };
        }

        static void ApplyFormColors(ColorTheme theme, Form form)
        {
            form.BackColor = theme.ColorBg;
            form.ForeColor = theme.FontColor;
        }

        static void ApplyLabelColors(ColorTheme theme, Label label)
        {
            if(label.Name.Contains("Money"))
            {
                label.BackColor = theme.ColorBg;
                label.ForeColor = theme.MoneyFontColor;
            }
            else if(label.Name == "labelTimerDisplay")
            {
                label.BackColor = theme.ColorBg;
                label.ForeColor = theme.TimerColor;
            }
            else
            {
                label.BackColor = theme.ColorBg;
                label.ForeColor = theme.FontColor;
            }
        }

        static void ApplyListViewColors(ColorTheme theme, ListView LV)
        {
            LV.ForeColor = theme.FontColorListViewCaption;
            LV.BackColor = theme.ColorBg;
        }
    }
}
