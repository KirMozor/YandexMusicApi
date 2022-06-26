Promocode
================================
Этот метод активирует промокод на ваш аккаунт

Входные данные:
----------

* Токен
* Промокод: string promocode
* Язык: string language

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
