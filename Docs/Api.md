# Buber Dinner Api

- [Buber Dinner Api](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```json
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "juancar",
  "lastName": "talavan",
  "email": "jctalavan8@gmail.com",
  "password": "mbappe2023"
}
```

#### Register Response

```json
200 OK
```

```json
{
  "id": "b0366c7a-eea1-4cf1-b7e4-e975c61c43a2",
  "firstName": "juancar",
  "lastName": "talavan",
  "email": "jctalavan8@gmail.com",
  "password": "mbappe2023"
}
```

### Login

```json
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "jctalavan8@gmail.com",
  "password": "mbappe2023"
}
```

#### Login Response

```json
200 OK
```

```json
{
  "id": "b0366c7a-eea1-4cf1-b7e4-e975c61c43a2",
  "email": "jctalavan8@gmail.com",
  "password": "mbappe2023"
}
```
