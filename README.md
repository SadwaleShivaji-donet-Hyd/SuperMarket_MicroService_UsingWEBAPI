# 🛒 SuperMarket Microservice Using ASP.NET Core Web API

This project demonstrates a **microservices-based Supermarket application** built with **ASP.NET Core Web API** and **Ocelot API Gateway**.

It contains two core services:
- **Product Microservice** — handles product CRUD operations.
- **Order Microservice** — acts as a client to fetch products and create new orders.

The **API Gateway (Ocelot)** manages routing between these microservices, exposing unified endpoints to external clients.

---

## 🧩 Architecture Overview

Client
│
▼
[ Ocelot API Gateway ]
├──► Product Microservice → CRUD operations for products
└──► Order Microservice → Fetch products & create orders
SuperMarket_MicroService_UsingWEBAPI/
│
├── ProductMicroservice/
│ ├── Controllers/
│ ├── Models/
| ├── Migrations/
│ └── appsettings.json
│
├── OrderMicroservice/
│ ├── Controllers/
│ ├── Models/
| ├── Migrations/
│ └── appsettings.json
│
└── ApiGateway/
└── ocelot.json

##  How It Works

1. The **Product Microservice** provides APIs to manage products (`GET`, `POST`, `PUT`, `DELETE`).
2. The **Order Microservice** consumes the Product service API to list products and create orders.
3. The **Ocelot API Gateway** routes requests from the client to the correct microservice.


