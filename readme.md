[![Build status](https://ci.appveyor.com/api/projects/status/wyrbbo7tnjobcvpa?svg=true)](https://ci.appveyor.com/project/igi/iestring)

---

# IEString

A small webapi to return strings from Infinity Engine games

## Usage

IEString exposes three endpoints:
  /random -> return a random string
  /{game}/random -> return a random string from a given game
  /{game}/{strref} -> return a specific string from a given game
  
Games are defined in the database; currently supported games via tlktosql are:
  bg
  bg2
  bgee
  bg2ee
  iwdee
  pst
  pstee
  sod


## Download

You can [download](https://github.com/btigi/IEString/releases/) the latest version of IEString.


## Technologies

IEString is written in C# Net Core 5.


## Compiling

To clone and run this application, you'll need [Git](https://git-scm.com) and [.NET](https://dotnet.microsoft.com/) installed on your computer. From your command line:

```
# Clone this repository
$ git clone https://github.com/btigi/IEString

# Go into the repository
$ cd IEString

# Build  the app
$ dotnet build
```

IEString ships with an empty database - you will need to populate this in order to experience full functionality (see [tlktosql](https://github.com/btigi/tlktosql))


## Notes

The repository contains two dockerfiles:
./src/dockerfile -> used to run in a docker container when debugging via vs
./dockerfile -> used to deploy to fly (automatically obtaining a database from tlktosql)

Deployment to [https://fly.io/](https://fly.io/) is managed by 'fly.toml' file.


## License

IEString is licensed under [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)
