1-) Kullanıcı Giriş Sistemi (Form1)
-Kullanıcı adı ve şifre ile giriş
-Şifreler MD5 ile hashleniyor
-SQL Server üzerinden kimlik doğrulama
-Başarılı girişte ana menüye yönlendirme

2-) Kullanıcı Yönetimi (Form2)
-Yeni kullanıcı ekleme (stored procedure: up_KullaniciEkle)
-Kullanıcı silme
-Kullanıcı bilgilerini güncelleme
-Kullanıcı arama (kullanıcı adına göre)
-Kullanıcı listesini görüntüleme (DataGridView)

3-) Ana Sipariş Ekranı (GirisYapmis)
-Pizza siparişi alma
-Pizza boyutu seçimi (Küçük: 10 TL, Orta: 15 TL, Büyük: 20 TL)
-Adet seçimi
-Ekstra malzemeler (Sucuk, Sosis, Mantar, Kaşar, Peynir, Sebze)
-İçecek seçenekleri (Kola, Fanta, Sprite)
-Müşteri bilgileri (Ad, Soyad, Telefon, Adres)
-Otomatik fiyat hesaplama
-Sipariş listesi görüntüleme
-Sipariş temizleme
-Yazdırma desteği
-Tarih/saat gösterimi

4-) Müşteri Yönetimi (Musteriler)
-Yeni müşteri ekleme (stored procedure: up_MusteriEkle)
-Müşteri silme
-Müşteri listesini görüntüleme
-Müşteri bilgileri (Ad, Soyad, Telefon, Adres, Açıklama)

5-) Toptancı Yönetimi (Toptanciler)
-Yeni toptancı ekleme (stored procedure: up_ToptanciEkle)
-Toptancı silme
-Toptancı listesini görüntüleme
-Toptancı bilgileri (Firma İsmi, Telefon, Adres, Kişi Adı, Kişi Telefonu)

6-) Teknik Detaylar
-Platform: Windows Forms (.NET Framework 4.5.2)
-Veritabanı: SQL Server (GeceP3)
-Bağlantı: Uzak SQL Server 
-Güvenlik: MD5 hash ile şifreleme
-Veri Erişimi: Stored procedure ve doğrudan SQL sorguları
-Dataset: 9 adet DataSet (GeceP3DataSet - GeceP3DataSet9)

7-) Görsel Öğeler
-Pizza görselleri (13 adet)
-Pizza menü görselleri (5-6 adet)
-Ek ürün görselleri (5 adet)
-İçecek görselleri (3 adet)
