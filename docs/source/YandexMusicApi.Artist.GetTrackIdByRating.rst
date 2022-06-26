GetTrackIdByRating
==================================
Returns artist's best tracks.


Input data:
-----------

* Artist ID. string artistId

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
              Console.WriteLine(Artist.GetTrackIdByRating("675068")); // ArtistId: Imagine Dragons
           }
        }
     }
