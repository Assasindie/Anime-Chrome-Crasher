# Anime-Chrome-Crasher
A program that runs in the background and crashes chrome if the word anime is detected in the tab name. It will also send some information about your tabs and computer name to a discord webhook, aswell as take a screenshot of your primary screen.


To kill any instances of this program and if you had an old version remove it from startup, run the Remove Anime Chrome Crasher exe.


This is not intended for distribution or any use other than personal and is mearly to show the potential of what you can do a c# application running in the background, however feel free to contribute :).

USE AT YOUR OWN RISK.

## Installation
Via NuGet:

```
Install-Package Discord.Net
Install-Package DotNetEnv
```
Create .env File with the following information in the main folder
```
WEBHOOK_ID=

WEBHOOK_TOKEN=
```
