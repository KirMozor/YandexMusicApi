MoreInfoAlbum
==================================
Возвращает ещё бооольше информации об альбомах чем InfoAlbum, можно кинуть сразу кучу id-шников  


Входные данные:
-----------

* ID альбомов. List<string> albumsId

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
              var albumsId = new List<string>();

              albumsId.Add("13984185");
              albumsId.Add("13730064");
            
              Console.WriteLine(Album.MoreInformAlbums(albumsId));
           }
        }
     }
