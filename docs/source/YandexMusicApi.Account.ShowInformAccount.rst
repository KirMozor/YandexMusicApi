ShowInformAccount
========================================
Возвращает информацию об аккаунте


Входные данные:
-----------

* Токен

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
              Console.WriteLine(Account.ShowInformAccount());
           }
        }
     }
