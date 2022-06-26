GetTrackIdByRating
==================================
Возвращает лучшие треки артиста


Входные данные:
-----------

* ID артиста. string artistId

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
              Console.WriteLine(Artist.GetTrackIdByRating("675068")); // ArtistId: Imagine Dragons
           }
        }
     }
