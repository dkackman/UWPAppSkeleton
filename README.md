# UWPAppSkeleton
Project Template for an MMVM Light Universal App

This here is the basis Visual Studio project template that will create the skeleton of an app that looks and feels a lot like the built in Microsoft Windows 10 app (Weather, NFL etc). It's got all the basic stuff plumbed out like navigation and a navigation control, a settings page, Theme switch etc.

There is a [Visual Studio extensibility package](https://visualstudiogallery.msdn.microsoft.com/909387a1-1483-4637-b536-f36692c0bc88) up on the community site.

If you use [MVVM Light](https://visualstudiogallery.msdn.microsoft.com/909387a1-1483-4637-b536-f36692c0bc88) the resulting project code will look pretty familiar, and there are some TODO comments to show where to plug in the specifics for your app. If you start with the Code from this repository replace all instances of the string "SKELETON" with you app namespace name. Starting from the code in this repository is not recomended as the you won't get the autogenerated package family name in the app manifest (though you can update manualy in the Xml of that file).
