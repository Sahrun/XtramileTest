# WeatherMap


An application to read the weather in real time around the world


**How to set the application**

- Download the source code to run the application on your local machine
- Open project from IDE is recommended to use visual studio

**App setting **
- Add the appsettings.json file to the WeatherAPI project to add configuration, then add the following properties

  - "OpenweatherBaseURL": "http://api.openweathermap.org/data/2.5/weather"
  - "OpenweatherAppId": "1d12aa37baa8e0cee75bb42acc519968"
  
  
 **API **
 Here is the api that is already available and you can use it with method GET :
 - To fetch country data {{host}}/api/weatherforecast/GetCountries 
 - To fetch city data by country {{host}} api/weatherforecast/GetCities?search={{kode_negara}}
 - To retrieve weather data {{host}}/api/weatherforecast/GetWeather?city={{kota}}&country={{kode_nagara}}
 - Result :
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

**UI**

![image](https://user-images.githubusercontent.com/13058978/224521627-e6f6dd06-df34-45b0-af35-020396e8790d.png)

![image](https://user-images.githubusercontent.com/13058978/224523224-17f4f808-0e86-4b9e-a679-a478e7059eed.png)




For weather data sources, you can register and learn more at https://openweathermap.org/


