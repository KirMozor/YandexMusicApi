GetTrack
==================================
Возвращает треки исполнителей


Входные данные:
-----------

* ID артиста. string artistId
* Страница выдачи. string page. Параметр по умолчанию 0
* Размер выдачи (кол-во элементов в ней). string pageSize. Параметр по умолчанию 20

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
              Console.WriteLine(Artist.GetTrack("675068")); //Aritst: Imagine Dragons
           }
        }
     }
