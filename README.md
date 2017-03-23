# Argo Server Query Tool (WIP)

##### Keep track of your CS:GO game servers and issue RCON commands with ease.
------------

**This is currently a work in progress, and this branch is being developed specifically for use within the /r/GlobalOffensive subreddit modteam. In order for this to work for anyone outside of our modteam, you will need to edit several things...**

Once completed, a public branch will be offered that will allow you to easily customize everything that is currently not customizable through the program menu's. If you are ***really*** interested in using it now, feel free to contact me and I'll help you set it up the best I can.

### Requirements
* [QueryMaster](https://querymaster.codeplex.com/) - .NET library to query/control any Source/GoldSource server.
* [System.Data.SQLite](https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki) - An ADO.NET provider for SQLite.
* [TS3QueryLib](https://ts3querylib.codeplex.com/) - a type safe library for querying over the server query port.
* [GetPugScore](https://github.com/ericwoolard/CS-GO-GetPugScore) - (Optional) This plugin was created by me to allow us to retrieve the current score for a game. It simply registers an admin command `getpugscore` and ASQT uses this to update the current score of a match. 

### About ASQT

Argo Server Query Tool was created for the r/globaloffensive subreddit modteam, to assist with our weekly Community Night 10-mans, where we playtest new maps created by members of the community. We had previously used HLSW, but it's become outdated and there are several features it lacks that are included with ASQT, such as live score updates, and TeamSpeak integration to make it easier to issue common commands. This is currently a work in progress. Feel free to contribute!

If you have questions, suggestions etc feel free to also contact me on [Reddit](https://www.reddit.com/user/zebradolphin5/) or [Steam](http://steamcommunity.com/id/warlordtv/)!

![Main Window](https://i.imgur.com/YUvb2YT.png)

## Features

* Create multiple server lists and view live updates for Ping, Map, Players, Version, and Score (if using getpugscore plugin)
* Send RCON commands to any server, or all servers in the list at once (useful for loading a map on all servers at once)
* Easily kick/ban any player from a server and/or TeamSpeak through the player list section
* Add info to a server by right clicking>Add Info to easily keep track of your servers
* Quick-command list by right clicking the command textbox
* Easily view in-game chat logs and respond from ASQT
* Built-in TeamSpeak 3 commands and a TeamSpeak 3 config panel
* *more to come!*

## License

* [MIT License](https://opensource.org/licenses/MIT)