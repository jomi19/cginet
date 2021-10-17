# cginet
Running on port: 5000

## dotnet run
Startar apit

# Paths
### POST /wordlist
body
```json
{
  "text": "text där du vill räkna orden"
}
```

```
curl -d "text=hej" -X POST http://localhost:5000/wordlist

Respons
{
    "hej": 1
}
```