# Launch Pads

A basic .net core skills demo. 

## Running in docker:

Clone the repo and cd to root:
```sh
git clone https://github.com/aaronpropst/launchpads.git
cd launchpads
```

## Run Unit tests in docker:
```
docker run -it -v $(pwd):/data -w /data/LaunchPadsTest mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet test
```

## Run Api Server in Docker:
```
docker run -it -p 5000:5000 -v $(pwd):/data -w /data/LaunchPads mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet run --urls http://0.0.0.0:5000
```
You should then be able to navigate to:

| | |
| --- | --- |
| [launchpads/](http://0.0.0.0:5000/api/launchpads/) | http://0.0.0.0:5000/api/launchpads/  |
| [launchpads/:id](http://0.0.0.0:5000/api/launchpads/kwajalein_atoll) | http://0.0.0.0:5000/api/launchpads/kwajalein_atoll  |