Expirements
==================================
Show if your account is enrolled to Yandex Music Experiments.


Input data:
-----------

* Token

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
              Console.WriteLine(Account.Expirements());
           }
        }
     }
