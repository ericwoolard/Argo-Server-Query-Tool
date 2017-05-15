<a id="1.0.9.2"></a>
## 2017-04-21, Version 1.0.9.2

* The 'Ban Player From All Servers And TS' feature has been finished and is now working
* Added a new tab to the console section to view a list of server rules. From the list you can:
  * Edit and save the value of any server rule
  * Save the list of rules to a local text file 
* Added a new context menu item to player lists to view a players profile in your browser
* Added a new context menu item to player lists to copy the players IP address
* Added a new context menu item to the output text box to copy selected text
* Decreased height of main server list ListView and increased size of Console/Rules area
* Renamed Options GroupBox to Tools

  * #### Commits -
  * [[`d586883`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/d58688358ee9c345943317c8a8f20ed00f42313a#diff-aab2f5f19398d09ad8cc6d58bb3f8966R804)] - View player profile in browser
  * [[`ff8890f`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/ff8890fbf4ff664bb1f6a1d608333aa99ee07e87)] - Copy player IP address

### Fixes

* Improved server status check by handling ping separate from updates. Fixes incorrect offline status
* Fixed a bug in new players list when sorting by column. Players list now auto-sorts by kills in desc order

  * #### Commits -
  * [[`79c8caf`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/79c8caf61326171cdabd0a75b1d11e2d3543db9d)] - New PingCheck class for determining server status
  * [[`33ed25c`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/33ed25c4389e6f761edb56059b3da98c478d16fa#diff-aab2f5f19398d09ad8cc6d58bb3f8966R102)] - BackgroundWorker for ping check
  * [[`33ed25c`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/33ed25c4389e6f761edb56059b3da98c478d16fa#diff-aab2f5f19398d09ad8cc6d58bb3f8966R721)] - Improvements for new player list
  
### Misc

* Several code cleanups
* Organized project models to new models folder

  * #### Commits -


---

<a id="1.0.9.1"></a>
## 2017-04-18, Version 1.0.9.1

* Rewrote the code to populate player lists. Will now group players by team and show kills/deaths
* Added the ability to sort the players list by clicking on a column tab
* New PlayerModel.cs class to serve as a model for the new player list 
* Added QueryMaster binaries to repository

  * #### Commits -
  * [[`b05b4c7`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b05b4c70bb857c03086e1ad926c8f2c13722cb11#diff-da89dea23b3514c02526b9280d9a0ef9R250)] - Changes to Query.cs for new players list, retrieves players by team with their kills/deaths
  * [[`b05b4c7`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b05b4c70bb857c03086e1ad926c8f2c13722cb11#diff-aab2f5f19398d09ad8cc6d58bb3f8966R652)] - Changes to MainForm to implement new players list model
  * [[`b05b4c7`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b05b4c70bb857c03086e1ad926c8f2c13722cb11#diff-aab2f5f19398d09ad8cc6d58bb3f8966R1274)] - Sort players list by clicking on a column tab
  * [[`2fd224a`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/2fd224a090065e2b64200f7a3e4eee568cbe11eb)] - New PlayerModel class for the new players list
  
  
### Fixes

* Minor improvements to the Updates class
* Various bug fixes with new players list

  * #### Commits -
  * [[`f27c2bc`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/f27c2bc5242d2888e8346ccf8e0ef577782f44be)] - Minor improvements to Updates.cs

---

<a id="1.0.8.7"></a>
## 2017-04-15, Version 1.0.8.7

* Made score checker failsafe and will disable itself after failing once to prevent rcon auto-bans
* Output box now shows the command and timestamp in red for better readability
* Added an option to the 'View' menu to open the saved server list directory in Windows Explorer

  * #### Commits -
  * [[`8430f7f`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/8430f7f4c6acebc4dd0f6a445611750eaac6954c#diff-da89dea23b3514c02526b9280d9a0ef9R81)] - Made score checker failsafe
  * [[`4748cec`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/4748cec4ffe6dfeb74d5680fef2bf97c1c92b6b7#diff-aab2f5f19398d09ad8cc6d58bb3f8966R375)] - Show timestamps and cmd in red for better readability
  * [[`4748cec`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/4748cec4ffe6dfeb74d5680fef2bf97c1c92b6b7#diff-aab2f5f19398d09ad8cc6d58bb3f8966R1101)] - Code to open Windows Explorer in the saved server list directory
  * [[`4748cec`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/4748cec4ffe6dfeb74d5680fef2bf97c1c92b6b7#diff-5ee5f82cadd972571b596a3156434523R1157)] - 'View saved server list location' added to designer
  * [[`4715c58`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/4715c58a64ccf24b9c5217d953c9574f72c778b4)] - Changes to Query.cs to accomodate colored timestamp/cmd output

### Fixes

* 'Ban From All Servers' menu option in player list now uses RCON2All methods and reports progress and results

  * #### Commits -
  * [[`4748cec`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/4748cec4ffe6dfeb74d5680fef2bf97c1c92b6b7#diff-aab2f5f19398d09ad8cc6d58bb3f8966R726)] - Ban From All Players update to use RCON2All methods

### Misc

* Cleaned up SQLite.cs and added a few comments 

  * #### Commits -
  * [[`ddf89cc`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/ddf89cc241ea52b798fec2d56f9475d8d7ca9581)]

---

<a id="1.0.8.6"></a>
## 2017-04-13, Version 1.0.8.6

* ASQT will now remember the last loaded server list and preload it at startup
* Added the ability to right click a player name in the player list and copy their SteamID
* When fetching player lists, `host_players_show` will now elevate to 2 for visibility, then return to a setting of 1
* Score check now disabled by default to improve polling speed and prevent RCON errors for lists using a different pass
* Polling time for server updates now slightly faster

  * #### Commits -
  * [[`b84c03e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b84c03efaf4cd174aac5822eaadf22600d525cb2#diff-aab2f5f19398d09ad8cc6d58bb3f8966R60)] - Preload the last loaded server list at startup
  * [[`b84c03e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b84c03efaf4cd174aac5822eaadf22600d525cb2#diff-aab2f5f19398d09ad8cc6d58bb3f8966R697)] - Copy player SteamID to clipboard by right clicking a players name in the player list
  * [[`bbcd44e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/bbcd44e796221d428aff7e5d390c8d5677239d56#diff-da89dea23b3514c02526b9280d9a0ef9R229)] - Update Players adjustments for fetching player list's

### Fixes

* Fixed a bug with command history causing the send button to stop working
* RCON2All now includes the number of failed cmd's in the output and omits them from total number of successful attempts
* Minor adjustments to the Send Status button to prevent some cases where it wouldn't alert of an error

  * #### Commits -
  * [[`b84c03e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b84c03efaf4cd174aac5822eaadf22600d525cb2#diff-aab2f5f19398d09ad8cc6d58bb3f8966R370)] - Command history bug fix 
  * [[`b84c03e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b84c03efaf4cd174aac5822eaadf22600d525cb2#diff-aab2f5f19398d09ad8cc6d58bb3f8966R955)] - RCON2All fix to show any failed attempts in the output
  * [[`bbcd44e`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/bbcd44e796221d428aff7e5d390c8d5677239d56#diff-da89dea23b3514c02526b9280d9a0ef9R162)] - Minor adjustments to 'Send Status' button

---

<a id="1.0.8.4"></a>
## 2017-04-05, Version 1.0.8.4

* Animated the TS config panel to slide in/out
* Added a context menu option to the players list to copy player names
* Added a context menu option to the command box to clear command history

  * #### Commits -
  * [[`70c247d`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/70c247d34778eff3032805f388c9dc82e57368a9)] - New TS3 config panel animation
  * [[`81b63bc`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/81b63bc12146654151109886eaee68d56a580096)] - Added 'copy player name' to playerList context menu, fixed green player count not resetting at 0
  * [[`815453b`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/815453bd086ed6203d273c0ca490005cbfc40671)] - Added context menu option to clear command history

### Fixes

* Fixed the TS config sometimes showing the saved indicator when it wasn't possible to save the config
* Fixed green color indicator on player count not resetting when count returns to 0
* Significantly reduced socket timeouts which previously added many seconds to an update iteration if a server was offline
* Fixed an issue that occasionally caused a failed RCON validation to not show the error

  * #### Commits -
  * [[`1d1a1b2`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/1d1a1b2b1dfd3808f642c529f2e5c3b8032b89c4)] - TS3 'saved' indicator bug fix
  * [[`81b63bc`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/81b63bc12146654151109886eaee68d56a580096)] - Fixed green player count not resetting at 0
  * [[`b7aeb24`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b7aeb24b0c39da2fe70f271dfd69899191a92995)] - Reduced socket timeout + fixed failed RCON validation bug

---

<a id="1.0.8.2"></a>
## 2017-03-26, Version 1.0.8.2

* Updated NA ip addresses in RegionsStruct.cs to reflect the recently moved server address for auto-build
* Updated assembly description for about box
* Server lists now save to a specific path in local appdata and will persist throughout any updates
* Command history no longer saves duplicate entries of a particular command
* Small tweaks to new score toggle

  * #### Commits -
  * [[`1657e82`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/1657e82fcaf7a0d4f210ce8c30e04764303c8beb)] - Updated IP's for new NA network
  * [[`a52a02a`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/a52a02aad4a90f853c07ff1c4b3a98643c5d07f9)] - See changelog v1.0.8.2
  * [[`b560186`](https://github.com/ericwoolard/Argo-Server-Query-Tool/commit/b5601867ec40f68f8d1f12581dddfdb061e0404b)] - Updated assembly description

---

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