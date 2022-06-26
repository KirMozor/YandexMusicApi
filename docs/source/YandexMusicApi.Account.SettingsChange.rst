SettingsChange
=====================================
This method is needed to change your account settings. Send the data in JSON format. If you don't know how, look at the Account.ShowSettings method.


Input data:
-----------

* Token
* JSON data

Usage example:
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
