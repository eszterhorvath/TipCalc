# Notes

## Core

Steps:
1. create a new .Net Standard project
2. add MvvmCross.Froms NuGet package to the project
3. create the service interface and implementation pair
4. add a ViewModel which
    - inherits from MvxViewModel
    - declares a dependency on the service interface on its constructor (dependency injection!)
    - presents a number of public properties each of which called RaisePropertyChanged internally
5. add the App.cs which
    - inherits from MvxApplication
    - registers the IService/Service pair
    - registers a ViewModel to use for when the app starts

Mvx: static class, acts as a singla place for both registering and resolving interfaces and their implementations

RaisePropertyChanged: the way to tell the base MvxViewModel that the data has changed (set accessort should call it)

## UI

in XAML and code.behind: change ContentPage to MvxContentPage
data binding: mvx:Bi.nd (by default: one way)

## Platform-specific things

Usually the same steps:
1. create a new platform-specific project
2. add MvvmCross.Froms NuGet package to the project
3. add reference to the Core and UI projects
4. modify the platform-specific ‘Application’ to let MvvmCross be initialized
5. use the default provided Setup class for that platform
6. create a Views folder and add a platform-specific View (which inherites from something beginning with Mvx)
7. add data-binding to the platform view, targeting the ViewModel properties
8. press Run :)

## Android

MvvmCross.Forms version 7 needs min. SDK version 10 !!

MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<App, FormsApp>, App, FormsApp>

## iOS

AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<App, FormsApp>, App, FormsApp>

## UWP

TipCalcApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, FormsApp>, Core.App, FormsApp, MvxFormsWindowsPage>
