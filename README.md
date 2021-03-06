[![forthebadge](http://forthebadge.com/images/badges/fuck-it-ship-it.svg)](http://forthebadge.com) [![forthebadge](http://forthebadge.com/images/badges/no-ragrets.svg)](http://forthebadge.com) 
[![forthebadge](http://forthebadge.com/images/badges/60-percent-of-the-time-works-every-time.svg)](http://forthebadge.com)

[![forthebadge](http://forthebadge.com/images/badges/made-with-c-sharp.svg)](http://forthebadge.com)

# Argo Server Query Tool (WIP)

##### Keep track of your CS:GO game servers and issue RCON commands with ease.
------------

**This is currently a work in progress, and this branch is being developed specifically for use within the /r/GlobalOffensive subreddit modteam. In order for this to work for anyone outside of our modteam, you will need to edit several things...**

Once completed, a public branch will be offered that will allow you to easily customize everything that is currently not customizable through the program menu's. If you are ***really*** interested in using it now, feel free to contact me and I'll help you set it up the best I can.

### Requirements
* [QueryMaster](https://querymaster.codeplex.com/) - .NET library to query/control any Source/GoldSource server.
* [System.Data.SQLite](https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki) - An ADO.NET provider for SQLite.
* [TS3QueryLib](https://ts3querylib.codeplex.com/) - a type safe library for querying over the server query port.
* [ASQT-PugStats](https://github.com/ericwoolard/ASQT-Pug-Stats) - (Optional) I created this plugin to allow us to retrieve the current score for a game. It eventually evolved to have 2 additional commands which can be used by ASQT. 
  * `getpugscore` - responds with the current score of the match in the format `T's = 0, CT's = 0`
  * `getplayers` - returns a list of all players along with which team they're on and kill/death count. Used by ASQT to build the players list when clicking 'Update players'
  * `getplayerip <#userid|name>` - Returns the IP address of the player. Used by the r/globaloffensive modteam to track players when necessary, as their CS:GO/TS names aren't always the same

### About ASQT

Argo Server Query Tool was created for the r/globaloffensive subreddit modteam, to assist with our weekly Community Night 10-mans, where we playtest new maps created by members of the community. We had previously used HLSW, but it's become outdated and there are several features it lacks that are included with ASQT, such as live score updates, and TeamSpeak integration to make it easier to issue common commands. This is currently a work in progress. Feel free to contribute!

If you have questions, suggestions etc feel free to also contact me on [Reddit](https://www.reddit.com/user/zebradolphin5/) or [Steam](http://steamcommunity.com/id/warlordtv/)!

![Main Window](http://i.imgur.com/TX6IaJ8.png)

## Features

* Create multiple server lists and view live updates for Ping, Map, Players, Version, and Score (if using ASQT-PugStats plugin)
* Send RCON commands to any server, or all servers in the list at once (useful for loading a map on all servers at once)
* Easily kick/ban any player from a server and/or TeamSpeak through the player list section
* Add info to a server by right clicking>Add Info to easily keep track of your servers
* Quick-command list by right clicking the command textbox
* Easily view in-game chat logs and respond from ASQT (soon™)
* Built-in TeamSpeak 3 commands and a TeamSpeak 3 config panel
* *more to come!*

## License

* [GNU GPLv3](https://gitlab.com/rGlobalOffensive/Argo-Server-Query-Tool/blob/6aef726fc6134cb50a2cb9a768ef439c2e7a56e3/LICENSE)