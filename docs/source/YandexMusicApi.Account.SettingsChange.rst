SettingsChange
=====================================
Этот метод нужен для изменения настроек аккаунта. Данные надо отправлять в JSON. Если вы не знаете как, гляньте метод Account.ShowSettings


Входные данные:
-----------

* Токен
* JSON данные

Пример использования:
---------
.. code-block:: csharp
     :linenos:
        
     using System;
     using YandexMusicApi;

     namespace ConsoleApp1
     {
        class Program
        {
           static void Main(string[] args)
           {
              Token.token = "YOURTOKEN";
              string settings = "{\n\"theme\": \"black\", \n\"volumePercents\": 80, \n\"adsDisabled\": true \n}";
              Account.SettingsChange(settings);
           }
        }
     }
