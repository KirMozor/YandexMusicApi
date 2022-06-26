GetTracks
==================================
Возвращает треки альбома


Входные данные:
-----------

* ID альбома. string albumId

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
              Console.WriteLine(Album.GetTracks("17589377")); //AlbumId: Imagine Dragons
           }
        }
     }
