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