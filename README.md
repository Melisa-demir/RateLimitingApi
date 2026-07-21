# Rate Limiting API

A simple ASP.NET Core 8 Web API project to learn **Rate Limiting**.

## Technologies

- ASP.NET Core 8 Web API
- Rate Limiting Middleware

## Features

- Fixed Window Rate Limiting
- Sliding Window Rate Limiting
- Different policies for different endpoints
- IP-based rate limiting
- Custom 429 (Too Many Requests) response

## Endpoints

### Products

```http
GET /api/products
```

- Sliding Window policy
- Maximum **3 requests in 10 seconds**

### Login

```http
POST /api/auth/login
```

- Fixed Window policy
- Maximum **2 requests in 1 minute**

## Project Structure

```
Controllers

├── ProductsController
├── AuthController

```

## Response Example

```json
{
  "statusCode": 429,
  "message": "Too many requests. Please try again later."
}
```

## Concepts Learned

- ASP.NET Core Rate Limiting
- Fixed Window Algorithm
- Sliding Window Algorithm
- Rate Limiting Policies
- IP-based Rate Limiting
- Custom Rate Limit Responses