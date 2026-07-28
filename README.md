# Balance Ball 3D

Unity ile geliştirilmiş 3B denge/parkur oyunu. Topu joystick ile yönlendirip düşmeden bölüm sonuna ulaşmaya çalışırsınız. Süre sınırı, can sistemi ve checkpoint mekaniği vardır.

## 🎮 Tarayıcıda Oyna

**[▶ Oyunu WebGL ile oyna](https://kayasibel.github.io/Balance-Ball/WebGL/)**

Kurulum gerektirmez, doğrudan tarayıcıda çalışır. İlk açılışta oyun dosyaları indirileceği için birkaç saniye sürebilir.

> Masaüstü tarayıcılarda Chrome, Edge ve Firefox ile test edilmiştir. Mobil tarayıcılarda WebGL performansı cihaza göre değişebilir; mobil için Play Store sürümü önerilir.

## 📱 Android

Oyunun Android sürümü Google Play'de yayında:

**[Google Play'de görüntüle](https://play.google.com/store/apps/details?id=com.SibelKaya.Ballance3D)**

## Oynanış

| | |
|---|---|
| **Hareket** | Sol joystick — topa tork uygulanır |
| **Kamera** | Sağ joystick — top etrafında yatay dönüş |
| **Amaç** | Süre dolmadan bitiş noktasına ulaşmak |
| **Can** | Tehlikeye değince can azalır, son checkpoint'ten devam edilir |
| **Süre** | Haritadaki toplanabilirler +5 saniye kazandırır |

## Teknik Detaylar

- **Unity 6000.3.6f1** (Unity 6.3 LTS)
- **Bölümler:** 20 ana bölüm + ekstra bölümler, ana menü ve bölüm seçme ekranı
- **Fizik:** Rigidbody tabanlı top kontrolü (tork ile hareket)
- **Kamera:** Oyuncu etrafında yaw/pitch tabanlı orbit kamera
- **Reklam:** Google Mobile Ads (ödüllü reklam) — yalnızca Android
- **Scripting Backend:** IL2CPP

### Android build ayarları

| Ayar | Değer |
|---|---|
| Target SDK | 36 (Android 16) |
| Min SDK | 25 (Android 7.1) |
| Mimari | ARMv7 + ARM64 |
| Format | Android App Bundle (.aab) |

## Projeyi Derleme

Depoyu klonlayıp Unity Hub üzerinden **Unity 6000.3.6f1** ile açın.

### WebGL

```
File > Build Settings > WebGL > Switch Platform > Build
```

Çıktı klasörü olarak depo kökündeki `WebGL/` seçilmelidir. GitHub Pages `Content-Encoding` başlığı ayarlayamadığı için Player Settings'te şu ayarlar zorunludur:

- **Compression Format:** Gzip
- **Decompression Fallback:** açık

Bu ikisi olmadan yayınlanan sayfa yüklenmeden takılır.

### Android

```
File > Build Settings > Android > Switch Platform > Build
```

İmzalama için `Player Settings > Publishing Settings` altında keystore tanımlanmalıdır. Keystore dosyaları depoya dahil değildir (`.gitignore`).

## Proje Yapısı

```
Assets/
├── Codes/          Oyun scriptleri (kamera, can, checkpoint, menü, reklam)
├── Scenes/         Ana menü, bölümler, bölüm seçme
│   └── ExtraLvl/   Ekstra bölümler
├── Prefabs/        Top, kamera, UI prefab'ları
├── Asset/          Joystick paketi ve Standard Assets
└── Plugins/        Android manifest ve Gradle şablonları

WebGL/              Yayınlanan WebGL build (GitHub Pages)
```

## Lisans

Bu depodaki üçüncü taraf paketler (Joystick Pack, Unity Standard Assets, Google Mobile Ads) kendi lisanslarına tabidir.
