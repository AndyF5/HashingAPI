# HashingAPI
A very simple API and interface to hash and salt a string with the PBKDF2 algorithm.

```
GET - /api/hash/stringToHash

POST - /api/hash
  {
    "stringToHash": "string", // Required
    "iterations": 1000
  }
```
