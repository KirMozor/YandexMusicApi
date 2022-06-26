GetBriefInfo
==================================
Returns artist news.

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
              Console.WriteLine(Artist.GetBriefInfo("675068")); //ArtistId: Imagine Dragons
           }
        }
     }
