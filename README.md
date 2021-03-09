# 🐟 Fish Game

## 💬 What is this?
Fish Game is a 2-4 player online game built in the Unity game engine, as an example of how to use the [Nakama Open Source Game Server](https://heroiclabs.com/nakama-opensource/) game server with Unity.

It demonstrates the following Nakama features:
- [Device Authentication](https://heroiclabs.com/docs/authentication/#device)
- [Matchmaking](https://heroiclabs.com/docs/gameplay-matchmaker/)
- [Realtime Multiplayer](https://heroiclabs.com/docs/gameplay-multiplayer-realtime/)

The game design is heavily inspired by [Duck Game](https://store.steampowered.com/app/312530/Duck_Game/).

## 🛠️ Getting started
To get started you will first need to install [Docker Desktop](https://www.docker.com/get-started).

Once you have installed Docker Desktop, you will find a `docker-compose.yml` file in the root directory of the project.

Open a terminal/command prompt here and type:
```
docker-compose up
```

This will spin up the Nakama Game Server and an instance of CockroachDB which Nakama uses to store data.

The game has been developed using Unity 2019.4.19f1 and should work on any iteration of 2019.4.

Open up the `FishGame` project in Unity 2019.4, go to **File** -> **Build Settings** and build the game for your chosen platform. You should then be able to launch two instances of the game to test locally.

## 🕹️ Controls

- **A** or **Left Arrow** - Move Left
- **D** or **Right Arrow** - Move Right
- **Space** - Jump (Hold to jump higher)
- **Left Mouse** or **CTRL** - Shoot

## 📜 License
This project is licensed under the [Apache 2.0 License](https://www.apache.org/licenses/LICENSE-2.0), with the following exceptions:

- The Pixellari font is licensed under the [SIL Open Font License 1.1](https://opensource.org/licenses/OFL-1.1) and is made by [Zedseven](https://github.com/zedseven/Pixellari).
- The artwork and music is licensed under the [PolyForm Noncommercial License 1.0.0](LICENSE.md).

## 🎉 Development
This project was developed by [Code With Tom](https://www.codewithtom.com) and kindly sponsored by [Heroic Labs](https://heroiclabs.com/), the awesome people behind the [Nakama Open Source Game Server](https://heroiclabs.com/nakama-opensource/).