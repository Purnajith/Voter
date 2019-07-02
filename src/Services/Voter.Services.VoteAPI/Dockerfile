FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Services/Voter.Services.VoteAPI/Voter.Services.VoteAPI.csproj", "src/Services/Voter.Services.VoteAPI/"]
RUN dotnet restore "src/Services/Voter.Services.VoteAPI/Voter.Services.VoteAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/Voter.Services.VoteAPI"
RUN dotnet build "Voter.Services.VoteAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Voter.Services.VoteAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Voter.Services.VoteAPI.dll"]