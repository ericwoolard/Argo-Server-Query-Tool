<a id="1.0.8.2"></a>
## 2017-03-26, Version 1.0.8.2

* Updated NA ip addresses in RegionsStruct.cs to reflect the recently moved server address for auto-build
* Updated assembly description for about box
* Server lists now save to a specific path in local appdata and will persist throughout any updates
* Command history no longer saves duplicate entries of a particular command
* Small tweaks to new score toggle

### Commits

* [[`1657e82`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/1657e82fcaf7a0d4f210ce8c30e04764303c8beb)] - Updated IP's for new NA network
* [[`a52a02a`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/a52a02aad4a90f853c07ff1c4b3a98643c5d07f9)] - See changelog v1.0.8.2
* [[`b560186`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b5601867ec40f68f8d1f12581dddfdb061e0404b)] - Updated assembly description


<a id="1.0.8.1"></a>
## 2017-03-22, Version 1.0.8.1

* Added new TS commands. Move channel, enable/disable host message mode (off/modal), mute channel
* Added region selection to serve as the basis for TS commands
* New Auto-Build feature to add complete server lists by region
* Score updater can now be toggled on/off from a new button in the tool strip
* Added AdminChat class to log in-game chat and type back with /say
* Commands are now stored to history, retrievable by opening the cmd list or scrolling while cmd textbox selected
* Player count will now show in green if at least one player has joined the server
* Added options to the context menu when right-clicking on a server to copy server address or map name to clipboard
* Added common commands and changelevel context menus to the command textbox to select from commonly used cmds or maps
* Added temporary (maybe?) first launch message

### Fixes

* Info saved to servers in the server list is now persistent and will load when reopening a server list
* Added optimized double buffering to the ListView to reduce any flickering
* Fixed a case where an exception was thrown if attempting to use a TS3 command without filling in the entire TS config
* Filtered OpenFileDialog to sqlite filetypes only
* Fixed a case where new server lists could be saved with illegal characters in their name
* Saved server list files now correctly save to Local AppData instead of the base program directory
* Several other bug fixes

### Commits

[[`3f2d82c`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/3f2d82c)]