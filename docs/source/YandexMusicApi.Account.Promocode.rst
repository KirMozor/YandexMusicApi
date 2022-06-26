Promocode
================================
This method redeems a promocode to your account.

Input data:
----------

* Token
* Promocode: string promocode
* Language: string language

Пример использования:
----------
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
                    Console.WriteLine(Account.Promocode("12312", "ru"));
               }
          }
     }
