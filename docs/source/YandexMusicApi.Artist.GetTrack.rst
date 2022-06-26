GetTrack
==================================
Returns songs of an artist.


Input data:
-----------

* Artist ID. string artistId
* Output page. string page. Default value: 0
* Output size (how much elements in a page). string pageSize. Default value: 20

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
              Console.WriteLine(Artist.GetTrack("675068")); //Aritst: Imagine Dragons
           }
        }
     }
