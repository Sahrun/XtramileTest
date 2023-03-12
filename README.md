# WeatherMap


sebuah aplikasi untuk membaca cuaca secara langsung di seluruh dunia


**Cara setting aplikasi **

- Download sourcode untuk menjalankan aplikasi di komputer local anda 
- Open project from IDE disarankan menggunakan visual studio

**App setting **
- Tambahkan file appsettings.json pada project WeatherAPI untuk menambahkan konfigurasi , kemudian tambahkan properti berikut ini
   "OpenweatherBaseURL": "http://api.openweathermap.org/data/2.5/weather",
   "OpenweatherAppId": "1d12aa37baa8e0cee75bb42acc519968"
  
  
 **API **
 Berikut adalah api yang sudah tersedia dan anda bisa menggunakan nya :
 - Untuk mengambil data negara {{host}}/api/weatherforecast/GetCountries
 - Untuk mengambil data kota berdasarkan negara {{host}} api/weatherforecast/GetCities?search={{kode_negara}}
 - Unutk mengambil data cuaca {{host}}/api/weatherforecast/GetWeather?city={{kota}}&country={{kode_nagara}}
 - Hasil :
  {
    "name": "Jakarta",
    "timezone": 25200,
    "wind": 6.71,
    "visibility": 10000,
    "sky": "overcast clouds",
    "celsius": 31.089996,
    "fahrenheit": 113.56199,
    "dewPoint": 96,
    "humidity": 71,
    "pressure": 1012
}

**Tampilan UI**

![image](https://user-images.githubusercontent.com/13058978/224521627-e6f6dd06-df34-45b0-af35-020396e8790d.png)

![image](https://user-images.githubusercontent.com/13058978/224521643-fb346690-7f81-4eb3-b428-70d8ecc26c0e.png)



Untuk sumber data cuaca anda bisa daftar dan mempelajari lebih lanjut di https://openweathermap.org/


