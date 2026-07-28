# Balance Ball 3D

A 3D balance and obstacle course game built with Unity. Steer the ball with the joystick and reach the end of each level without falling off. Features a time limit, a health system and checkpoints.

## 🎮 Play in Your Browser

**[▶ Play the WebGL build](https://kayasibel.github.io/Balance-Ball/WebGL/)**

No installation required — it runs directly in the browser. The first load may take a few seconds while the game files download.

> Tested on desktop Chrome, Edge and Firefox. WebGL performance on mobile browsers varies by device; the Play Store build is recommended for mobile.

## 📱 Android

The Android version is live on Google Play:

**[View on Google Play](https://play.google.com/store/apps/details?id=com.SibelKaya.Ballance3D)**

## Gameplay

| | |
|---|---|
| **Movement** | Left joystick — applies torque to the ball |
| **Camera** | Right joystick — orbits horizontally around the ball |
| **Goal** | Reach the finish before the timer runs out |
| **Health** | Hitting a hazard costs health and returns you to the last checkpoint |
| **Time** | Collectibles scattered across the level grant +5 seconds |

## Technical Details

- **Unity 6000.3.6f1** (Unity 6.3 LTS)
- **Levels:** 20 main levels plus extra levels, a main menu and a level select screen
- **Physics:** Rigidbody-based ball control driven by torque
- **Camera:** Yaw/pitch orbit camera that rebuilds its transform each frame, so the pitch angle stays fixed and roll never drifts
- **Ads:** Google Mobile Ads (rewarded) — Android only
- **Scripting Backend:** IL2CPP

### Android build settings

| Setting | Value |
|---|---|
| Target SDK | 36 (Android 16) |
| Min SDK | 25 (Android 7.1) |
| Architectures | ARMv7 + ARM64 |
| Format | Android App Bundle (.aab) |

## Project Structure

```
Assets/
├── Codes/          Game scripts (camera, health, checkpoints, menus, ads)
├── Scenes/         Main menu, levels, level select
│   └── ExtraLvl/   Extra levels
├── Prefabs/        Ball, camera and UI prefabs
├── Asset/          Joystick Pack and Standard Assets
└── Plugins/        Android manifests and Gradle templates

WebGL/              Published WebGL build (served by GitHub Pages)
```

## License

Third-party packages included in this repository (Joystick Pack, Unity Standard Assets, Google Mobile Ads) are subject to their own licenses.
