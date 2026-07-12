# LightBar For Keyboard

LightBar For Keyboard is a lightweight, system-integrated Windows application designed to create a bright white bar at the bottom of your screen. It serves as a software-based keyboard light, reflecting light from your monitor down onto your laptop or desktop keyboard in low-light environments.

## Features

- **Docked Mode (Default)**: Registers itself as a native Windows Application Desktop Toolbar (AppBar). It securely locks above the taskbar and pushes maximized windows (like Chrome or VS Code) upward so they never cover your light source.
- **Floating Mode**: Need to see what's hidden underneath or at the bottom of your screen? Switch to Floating Mode, and you can left-click and drag the bar anywhere vertically or horizontally.
- **Context Menu**: Right-click anywh# LightBar For Keyboard

LightBar For Keyboard is a lightweight, system-integrated Windows application designed to create a customizable light bar at the bottom of your screen. It serves as a software-based keyboard light, reflecting light from your monitor down onto your laptop or desktop keyboard in low-light environments.

## Features

- **Color Profiles & OLED Optimization**: Choose from multiple colors optimized for contrast and energy savings:
  - **White**: Standard brightness.
  - **Pure Green**: Maximum contrast on dark keys.
  - **Pure Red**: Protects night vision and offers the lowest power draw.
  - **Yellow**: Warm, eye-friendly light.
- **Docked Mode (Default)**: Registers as a native Windows Application Desktop Toolbar (AppBar). It securely locks above the taskbar and pushes maximized windows upward so they never cover your light source.
- **Floating Mode**: Switch to Floating Mode to freely drag the bar anywhere vertically or horizontally.
- **Single Instance Engine**: Automatically prevents multiple overlapping bars from opening accidentally.
- **High DPI Support**: Fully optimized for Windows 11 display scaling, ensuring the bar remains exactly 40 pixels high on any monitor setup.

## Energy Efficiency vs. Hardware Lighting

Why use software to light your keyboard instead of a physical illuminated keyboard or a USB lamp? The answer is energy efficiency and convenience.

**Hardware Consumption (Illuminated Keyboard / USB Lamp):**
A standard USB port supplies 5 V. Depending on the number and intensity of the LEDs, a physical light consumes constant extra power:

- Minimum (small USB lamp): 5 V * 0,1 A = **0,5 W**
- Maximum (RGB keyboard / bright lamp): 5 V * 0,5 A = **2,5 W**

**LightBar Software Consumption:**
Our application leverages the screen you are already using.

- **LCD Monitors (IPS, TN, VA):** The backlight is already on. Displaying a white or colored bar merely twists the liquid crystals to let existing light through. **Extra power required: 0 W.**
- **OLED Monitors:** Each pixel generates its own light. While a full white bar uses about **2,0 W**, we introduced pure color profiles to bypass subpixel activation and save battery:
  - **Pure Green:** ~0,5 W (75% savings)
  - **Pure Red:** ~0,3 W (85% savings)
  - **Yellow:** ~0,8 W (60% savings)

**The Verdict:** On standard LCD screens, LightBar costs literally zero extra energy, making it infinitely more efficient than hardware lighting. On OLEDs, pure color modes provide excellent contrast at a fraction of a watt, while protecting your night vision and eliminating cable clutter entirely.

## How to Use

1. **Launch**: Install the application using the setup file, or double-click the portable `LightBarForKeyboard.exe`.
2. **Change Color**: Right-click anywhere on the bar and select your preferred color profile.
3. **Move (Floating Mode)**: Right-click the bar, select **Floating Mode**, then hold down the **left mouse button** to drag it.
4. **Lock (Docked Mode)**: Right-click the bar and select **Docked Mode** to pin it back to the bottom edge.
5. **Close**: Right-click and choose **Exit**.

## Download

You can download the latest Setup Installer or the portable standalone executable from the Releases section:
👉 **[Download LightBar For Keyboard Latest Release](https://github.com/MediaExpres/LightBarForKeyboard/releases)**

## License & Copyright

© 2026 MediaExpres. All rights reserved.

This software is **Free to use and modify** under the following conditions:

- **Attribution**: You must give appropriate credit to the original source.
- **Modification**: You are free to modify this code for your own needs.
- **No Warranty**: This software is provided "as-is", without warranty of any kind.ere on the white bar to seamlessly toggle between modes or exit the application.
- **High DPI Support**: Fully optimized for Windows 11 display scaling, ensuring the bar remains exactly 40 pixels high on any monitor setup.

## How to Use

1. **Launch**: Double-click `LightBarForKeyboard.exe`.
2. **Move (Floating Mode)**: Right-click the bar, select **Floating Mode**, then hold down the **left mouse button** to drag it.
3. **Lock (Docked Mode)**: Right-click the bar and select **Docked Mode** to pin it back to the bottom edge.
4. **Close**: Right-click and choose **Exit**, or press `Alt + F4` while the bar is active.

## Download

You can download the latest standalone executable from the Releases section:
👉 **[Download LightBar For Keyboard Latest Release](https://github.com/MediaExpres/LightBarForKeyboard/releases)**

## License & Copyright

© 2026 Media Expres SRL. All rights reserved.

This software is **Free to use and modify** under the following conditions:

- **Attribution**: You must give appropriate credit to the original source.
- **Modification**: You are free to modify this code for your own needs.
- **No Warranty**: This software is provided "as-is", without warranty of any kind.
